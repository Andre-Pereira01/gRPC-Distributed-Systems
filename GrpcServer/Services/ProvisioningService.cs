using Azure.Core;
using Google.Protobuf.Collections;
using Grpc.Core;
using GrpcServer;
using GrpcServer.Data;
using GrpcServer.Models;
using GrpcServer.Protos;
using GrpcService.Services;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using System.Data.Common;
using System.Text;

namespace GrpcServer.Services
{
    public class ProvisioningService : Provisioning.ProvisioningBase
    {
        private readonly SistD2Context _dbContext;
        private readonly ILogger<ProvisioningService> _logger;

        public ProvisioningService(ILogger<ProvisioningService> logger, SistD2Context dBContext)
        {
            _dbContext = dBContext;
            _logger = logger;
        }


        //SERVIÇO DE RESERVA
        public override Task<ReserveReply> Reserve(ReserveRequest request, ServerCallContext context)
        {
            try
            {
                var domicilio = _dbContext.Coberturas.FirstOrDefault(d => d.Rua == request.Rua && d.Numero == request.Num);
                if (domicilio == null || domicilio.Estado != "FREE")
                {
                    return Task.FromResult(new ReserveReply { Result = "Não pode reservar este domicilio." });
                }

                var user = _dbContext.Users.FirstOrDefault(u => u.Username == request.UserID && u.Password == request.Pass);

                domicilio.Operator = user.Operator;
                domicilio.Estado = "RESERVED";
                _dbContext.Coberturas.Update(domicilio);
                _dbContext.SaveChanges();

                var operacao = new Operacoes
                {
                    Operacao = "RESERVATION",
                    Operador = user.Operator,
                    NumAdministrativo = domicilio.NumAdmin,
                    Dataatual = DateTime.UtcNow
                };
                _dbContext.Operacoes.Add(operacao);

                _dbContext.SaveChanges();

                return Task.FromResult(new ReserveReply { Result = "Reserva efetuada com sucesso.", NumAdministrativo = domicilio.NumAdmin });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");

                throw new RpcException(new Status(StatusCode.Internal, "Ocorreu um erro"));
            }
        }



        //SERVIÇO DE ATIVAÇÃO
        public override async Task<ActivateReply> Activate(ActivateRequest request, ServerCallContext context)
        {
            try
            {
                var user = _dbContext.Users.FirstOrDefault(u => u.Username == request.UserID && u.Password == request.Pass);

                var domicilio = _dbContext.Coberturas.FirstOrDefault(d => d.NumAdmin == request.NumAdministrativo);
                if (domicilio == null || (domicilio.Estado != "RESERVED" && domicilio.Estado != "DEACTIVATED") || domicilio.Operator != user.Operator)
                {
                    return new ActivateReply { Result = "Não pode ativar este domicilio.", CanActivate = false};
                }
                int estimatedTime = 5; // Tempo estimado em segundos

                ActivateServiceAsync(user, domicilio, estimatedTime);
                return new ActivateReply { Result = "Ativação iniciada com sucesso", ExpectedActivationTime = estimatedTime, CanActivate = true};
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");

                throw new RpcException(new Status(StatusCode.Internal, "Ocorreu um erro"));
            }
        }
        public void ActivateServiceAsync(User user, Cobertura cobertura, int estimatedTime)
        {
            // Atualizar estado da cobertura
            cobertura.Estado = "ACTIVATED";
            _dbContext.Coberturas.Update(cobertura);
             _dbContext.SaveChangesAsync();

            // Adicionar linha à tabela Operacoes
            var operacao = new Operacoes
            {
                Operacao = "ACTIVATION",
                Operador = user.Operator,
                NumAdministrativo = cobertura.NumAdmin,
                Dataatual = DateTime.UtcNow
            };
            _dbContext.Operacoes.Add(operacao);
             _dbContext.SaveChangesAsync();

             // Publicar mensagem no tópico EVENTS do RabbitMQ
             string activationMessage = $"Servico foi ativado para o {user.Username} com o Numero Administrativo {cobertura.NumAdmin}.";
             RabbitService.SendMessage(user.Username, activationMessage);
          
        }



        //SERVIÇO DE DESATIVAÇÃO
        public override async Task<DeactivateReply> Deactivate(DeactivateRequest request, ServerCallContext context)
        {
            try
            {
                var user = _dbContext.Users.FirstOrDefault(u => u.Username == request.UserID && u.Password == request.Pass);

                var domicilio = _dbContext.Coberturas.FirstOrDefault(d => d.NumAdmin == request.NumAdministrativo);
                if (domicilio == null || domicilio.Estado != "ACTIVATED" || domicilio.Operator != user.Operator)
                {
                    return new DeactivateReply { Result = "Não pode desativar este domicilio." };

                }
                int estimatedTime = 5; // Tempo estimado em segundos

                DeactivateServiceAsync(user, domicilio, estimatedTime);
                return new DeactivateReply { Result = "Desativação iniciada com sucesso", ExpectedActivationTime = estimatedTime }; 
            }
            catch (Exception ex)
            {
                // Log the exception or return an appropriate error message to the client
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");

                throw new RpcException(new Status(StatusCode.Internal, "Ocorreu um erro"));
            }
        }
        public void DeactivateServiceAsync(User user, Cobertura cobertura, int estimatedTime)
        {
            // Simular tempo de ativação
             Task.Delay(TimeSpan.FromSeconds(estimatedTime));

            // Atualizar estado da cobertura
            cobertura.Estado = "DEACTIVATED";
            _dbContext.Coberturas.Update(cobertura);
            _dbContext.SaveChangesAsync();

            // Adicionar linha à tabela Operacoes
            var operacao = new Operacoes
            {
                Operacao = "DEACTIVATION",
                Operador = user.Operator,
                NumAdministrativo = cobertura.NumAdmin,
                Dataatual = DateTime.UtcNow
            };
            _dbContext.Operacoes.Add(operacao);
             _dbContext.SaveChangesAsync();

            // Publicar mensagem no tópico EVENTS do RabbitMQ
            string activationMessage = $"Servico foi ativado para o {user.Username} com o Numero Administrativo {cobertura.NumAdmin}.";
            RabbitService.SendMessage(user.Username, activationMessage);
        }


        //SERVIÇO DE TÉRMINO
        public override async Task<TerminateReply> Terminate(TerminateRequest request, ServerCallContext context)
        {
            try
            {
                var user = _dbContext.Users.FirstOrDefault(u => u.Username == request.UserID && u.Password == request.Pass);

                var domicilio = _dbContext.Coberturas.FirstOrDefault(d => d.NumAdmin == request.NumAdministrativo);
                if (domicilio == null || domicilio.Estado != "DEACTIVATED" || domicilio.Operator != user.Operator)
                {
                    return new TerminateReply { Result = "Não pode terminar este domicilio." };

                }
                int estimatedTime = 5; // Tempo estimado em segundos

                TerminationServiceAsync(user, domicilio, estimatedTime);
                return new TerminateReply { Result = "Término iniciado com sucesso", ExpectedActivationTime = estimatedTime };
            }
            catch (Exception ex)
            {
                // Log the exception or return an appropriate error message to the client
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");

                throw new RpcException(new Status(StatusCode.Internal, "Ocorreu um erro"));
            }
        }
        public void TerminationServiceAsync(User user, Cobertura cobertura, int estimatedTime)
        {
            // Simular tempo de ativação
            Task.Delay(TimeSpan.FromSeconds(estimatedTime));

            // Atualizar estado da cobertura
            cobertura.Estado = "FREE";
            cobertura.Operator = null;
            cobertura.Modalidade = null;

            _dbContext.Coberturas.Update(cobertura);
            _dbContext.SaveChangesAsync();

            // Adicionar linha à tabela Operacoes
            var operacao = new Operacoes
            {
                Operacao = "TERMINATION",
                Operador = user.Operator,
                NumAdministrativo = cobertura.NumAdmin,
                Dataatual = DateTime.UtcNow
            };
            _dbContext.Operacoes.Add(operacao);
             _dbContext.SaveChangesAsync();

            // Publicar mensagem no tópico EVENTS do RabbitMQ
            string activationMessage = $"Servico foi ativado para o {user.Username} com o Numero Administrativo {cobertura.NumAdmin}.";
            RabbitService.SendMessage(user.Username, activationMessage);
        }


        //Mostrar toda a informação das operaçoes para o admin
        public override async Task<AllInfoReply> AllInfo(AllInfoRequest request, ServerCallContext context)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Username == request.UserID && u.Password == request.Pass);

            // Get all the Operacoes records
            var operacoes = await _dbContext.Operacoes.ToListAsync();

            // Convert the Operacoes records to OperacoMessage objects
            var operacoesMessages = operacoes.Select(o => new OperacoesMessage
            {
                Id = o.Id,
                Operator = o.Operador,
                Operacao = o.Operacao
                // Map other fields from the Operaco class as needed
            }).ToList();

            // Return the result
            return new AllInfoReply
            {
                Result = "Sucesso",
                Operacoes = { operacoesMessages }
            };
            
        }

        //Mostrar os domicilios que estao disponiveis/FREE para o admin
        public override async Task<FreeCoberturaReply> FreeCobertura(FreeCoberturaRequest request, ServerCallContext context)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Username == request.UserID && u.Password == request.Pass);

            // Get all the Coverage records with state = FREE
            var freeCobertura = await _dbContext.Coberturas.Where(c => c.Estado == "FREE").ToListAsync();

            // Convert the Coverage records to CoverageMessage objects
            var coberturaMessages = freeCobertura.Select(c => new CoberturaMessage
            {
                NumAdmin = c.NumAdmin,
                Rua = c.Rua,
                Nume = (int)c.Numero,
                State = c.Estado
            }).ToList();

            // Return the result
            return new FreeCoberturaReply
            {
                Result = "Sucesso",
                Coberturas = { coberturaMessages }
            };
            
        }
       
        //Função que vai buscar a base de dados e comparar a palavra passe e username do user para o login
        public override async Task<GetUserReply> GetUser(GetUserRequest request, ServerCallContext context)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Username == request.UserID && u.Password == request.Pass);
            if (user != null)
            {
                var reply = new GetUserReply
                {
                    UserID = user.Username,
                    Pass = user.Password,
                    IsAdmin = user.IsAdmin,
                    Operator = user.Operator
                };

                return reply;
            }

            // Caso o Utilizador não seja encontrado, retorne null ou um valor padrão
            return null;
        }

        //Função que vai guardar na base de dados  os dados do novo user ao registar
        public override Task<RegisterUserReply> RegisterUser(RegisterUserRequest request, ServerCallContext context)
        {
            // Verifique se o Utilizador já está registrado
            var existingUser = _dbContext.Users.FirstOrDefault(u => u.Username == request.UserID);
            if (existingUser != null)
            {
                throw new RpcException(new Status(StatusCode.AlreadyExists, "O Utilizador já está registrado."));
            }

            // Crie um novo objeto User e preencha com os dados da solicitação
            var newUser = new User
            {
                Username = request.UserID,
                Password = request.Pass,
                IsAdmin = request.IsAdmin,
                Operator = request.Operator
            };

            // Salve o novo Utilizador no banco de dados ou em outro local adequado
            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();

            // Crie e retorne uma resposta indicando que o Utilizador foi registrado com sucesso
            var reply = new RegisterUserReply
            {
                Message = "Utilizador registrado com sucesso."
            };

            return Task.FromResult(reply);
        }
        

    }
}
