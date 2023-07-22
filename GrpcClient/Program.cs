using Grpc.Net.Client;
using GrpcServer;
using GrpcServer.Protos;
using System;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using GrpcServer.Data;
using GrpcServer.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Azure.Core;
using Grpc.Core;
using System.Threading.Channels;

namespace GrpcClient
{
    public static class Program
    {
        
        private static User? User { get; set; } = null; // Estado do utilizador atual, utilizado para manter o estado de login

        public static async Task Main(string[] args)
        {

            // Cria uma ligação ao servidor gRPC
            var channel = GrpcChannel.ForAddress("http://localhost:5118");
            var client = new Provisioning.ProvisioningClient(channel);

            bool exit = false;
           
      

            while (!exit) // Entra num ciclo até que o utilizador escolha sair
            {
                Console.WriteLine("[Menu Inicial]");
                Console.WriteLine("[1] - Registar");
                Console.WriteLine("[2] - Login");
                Console.WriteLine("[0] - Sair");
                Console.Write("Escolha uma opção:");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 0:
                        exit = true;
                        break;
                    case 1:
                        Console.Clear();
                        await RegisterUser(client);
                        break;
                    case 2:
                        Console.Clear();
                        await LoginUser(client);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }

          
        }

        // Método assíncrono para registar um novo utilizador
        private static async Task RegisterUser(Provisioning.ProvisioningClient client)
        {
            Console.WriteLine("[Registar Utilizador]");
            Console.Write("Nome de Utilizador:");
            string userId = Console.ReadLine();

            Console.Write("Palavra-Passe:");
            string password = Console.ReadLine();

            Console.Write("Operador:");
            string operador = Console.ReadLine();

            Console.Write("É Administrador? (S/N):");
            bool isAdmin = Console.ReadLine().Equals("S", StringComparison.OrdinalIgnoreCase);

            // Cria uma nova solicitação de registo com os dados fornecidos pelo utilizador
            var request = new RegisterUserRequest
            {
                UserID = userId,
                Pass = password,
                Operator = operador,
                IsAdmin = isAdmin
            };

            try
            {
                // Tenta enviar a solicitação de registo ao servidor
                var reply = await client.RegisterUserAsync(request);
                // Se a solicitação for bem sucedida, informa ao utilizador que o registo foi bem sucedido
                Console.WriteLine("Utilizador registado com sucesso!");
            }
            catch (RpcException ex)
            {
                // Se ocorrer uma exceção durante a solicitação de registo, informa ao utilizador que ocorreu um erro
                Console.WriteLine("Erro ao registar utilizador: " + ex.Message);
            }
        }

        private static async Task LoginUser(Provisioning.ProvisioningClient client)
        {
            while (User == null)
            {

                // Solicita o nome de utilizador e a palavra-passe
                Console.WriteLine("[Login]");
                Console.Write("Username:");
                string userId = Console.ReadLine();

                Console.Write("Palavra-Passe:");
                string password = Console.ReadLine();

                // Cria uma nova solicitação para obter o utilizador
                var request = new GetUserRequest
                {
                    UserID = userId,
                    Pass = password
                };

                // Envia a solicitação ao servidor e aguarda a resposta
                var reply = await client.GetUserAsync(request);

                // Se a resposta não for nula, significa que as credenciais estão corretas
                if (reply != null)
                {
                    User = new User
                    {
                        Username = reply.UserID,
                        Password = reply.Pass,
                        IsAdmin = reply.IsAdmin,
                        Operator = reply.Operator
                    };
                }

                if (User == null)
                {
                    Console.WriteLine("Utilizador ou palavra-passe incorretos.");
                }
            }

            bool exit = false;
            Console.Clear();
            while (!exit)
            {
                if (!User.IsAdmin)
                {
                    // Menu para utilizadores não administradores
                    Console.WriteLine("[Menu Cliente]");
                    Console.WriteLine("[1] - Reserva");
                    Console.WriteLine("[2] - Ativação");
                    Console.WriteLine("[3] - Desativação");
                    Console.WriteLine("[4] - Terminação");
                    Console.WriteLine("[0] - Sair");
                    Console.Write("Escreva a opção desejada:");
                }
                else
                {
                    // Menu para administradores
                    Console.WriteLine("[Menu Administrador]");
                    Console.WriteLine("[5] - Domicílios disponíveis");
                    Console.WriteLine("[6] - Operações realizadas");
                    Console.WriteLine("[7] - Sair");
                    Console.Write("Escreva a opção desejada:");
                }

                // Processa a escolha do utilizador
                int choice = int.Parse(Console.ReadLine());

                // Verifica se o utilizador está a tentar acessar uma opção que não tem permissão
                if (!User.IsAdmin && choice > 4)
                {
                    Console.WriteLine("Acesso não autorizado.");
                    continue;
                }
                if (User.IsAdmin && choice < 5)
                {
                    Console.WriteLine("Acesso não autorizado.");
                    continue;
                }

                //implementar a meio da apresentação

                //if (User.IsAdmin)
                //{
                 //   RabbitService.ConnectRabitMQ("");
               // }
                //else
               // {
                    RabbitService.ConnectRabitMQ(User.Username);
              //  }



                switch (choice)
                {
                    case 0:
                        exit = true;
                        break;
                    case 1:
                        Console.Clear();
                        Console.WriteLine("[Reserva] \n");
                        ServicoReservar(client);
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("[Ativação] \n");
                        ServicoAtivar(client);
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("[Desativação] \n");
                        ServicoDesativar(client);
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("[Terminação] \n");
                        ServicoTerminar(client);
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("[Domicílios disponíveis] \n");
                        FreeCobertura(client);
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("[Todas as operações] \n");
                        AllInfo(client);
                        break;
                    case 7:
                        exit = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opção Inválida.");
                        break;
                }

                Console.WriteLine("Prima qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private static void ServicoReservar(Provisioning.ProvisioningClient client)
        {

            Console.Write("Rua:");
            string rua = Console.ReadLine();

            Console.Write("Número:");
            string numeroInput = Console.ReadLine();
            // Converte o número da casa para um inteiro
            int numero = int.Parse(numeroInput);

            var request = new ReserveRequest
            {
                Rua = rua,
                Num = numero,
                UserID = User?.Username,
                Pass = User?.Password
            };

            // Envia a solicitação para o servidor e recebe a resposta
            var response = client.Reserve(request);

            Console.WriteLine(response.Result);
            Console.WriteLine("Número Administrativo: " + response.NumAdministrativo);

            Console.ReadLine();
        }

        private static void ServicoAtivar(Provisioning.ProvisioningClient client)
        {
            Console.Write("Número administrativo:");
            string numInput = Console.ReadLine();
            // Converte o número administrativo para um inteiro
            int num_administrativo = int.Parse(numInput);

            var request = new ActivateRequest
            {
                NumAdministrativo = Convert.ToString(num_administrativo),
                UserID = User?.Username,
                Pass = User?.Password
            };

            // Envia a solicitação para o servidor e recebe a resposta
            var response = client.Activate(request);

            Console.WriteLine(response.Result);
            Console.WriteLine("Tempo estimado: " + response.ExpectedActivationTime + " segundos");
            Console.ReadLine();
        }

        private static void ServicoDesativar(Provisioning.ProvisioningClient client)
        {

            Console.Write("Número Administrativo:");
            string numInput = Console.ReadLine();
            // Converte o número administrativo para um inteiro
            int num_administrativo = int.Parse(numInput);

            var request = new DeactivateRequest
            {
                UserID = User?.Username,
                Pass = User?.Password,
                NumAdministrativo = Convert.ToString(num_administrativo)

            };

            // Envia a solicitação para o servidor e recebe a resposta
            var response = client.Deactivate(request);

            Console.WriteLine(response.Result);
            Console.WriteLine("Tempo estimado: " + response.ExpectedActivationTime + " segundos");
            Console.ReadLine();
        }

        private static void ServicoTerminar(Provisioning.ProvisioningClient client)
        {

            Console.Write("Número Administrativo:");
            string numInput = Console.ReadLine();
            int num_administrativo = int.Parse(numInput);

            var request = new TerminateRequest
            {
                NumAdministrativo = Convert.ToString(num_administrativo),
                UserID = User?.Username,
                Pass = User?.Password
            };

            var response = client.Terminate(request);

            Console.WriteLine(response.Result);
            Console.WriteLine("Tempo estimado: " + response.ExpectedActivationTime + " segundos");

            Console.ReadLine();
        }

        private static void AllInfo(Provisioning.ProvisioningClient client)
        {

            var request = new AllInfoRequest
            {
                UserID = User?.Username,
                Pass = User?.Password
            };

            var response = client.AllInfo(request);

            Console.WriteLine(response.Result);
            //Console.WriteLine("Tempo estimado: " + response.ExpectedActivationTime + " segundos");
            if (response.Result == "Sucesso")
            {
                foreach (var operacaoMessage in response.Operacoes)
                {
                    Console.WriteLine($"Operacao ID:{operacaoMessage.Id}, Operator:{operacaoMessage.Operator}, Operacao:{operacaoMessage.Operacao}");
                }
            }

            Console.ReadLine();
        }

        private static void FreeCobertura(Provisioning.ProvisioningClient client)
        {
            var request = new FreeCoberturaRequest
            {
                UserID = User?.Username,
                Pass = User?.Password
            };

            var response = client.FreeCobertura(request);

            if (response.Result == "Sucesso")
            {
                foreach (var coberturaMessage in response.Coberturas)
                {
                    Console.WriteLine($"Número administrativo: {coberturaMessage.NumAdmin},Rua:{coberturaMessage.Rua},Número:{coberturaMessage.Nume}, Estado: {coberturaMessage.State}");
                }
            }

            Console.ReadLine();
        }

    }
}

