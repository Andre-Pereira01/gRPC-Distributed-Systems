// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/provisioning.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981
#region Designer generated code

using grpc = global::Grpc.Core;

namespace GrpcServer.Protos {
  /// <summary>
  /// Defini��o do servi�o Provisioning que declara v�rias opera��es RPC
  /// </summary>
  public static partial class Provisioning
  {
    static readonly string __ServiceName = "provisioning.Provisioning";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcServer.Protos.ReserveRequest> __Marshaller_provisioning_ReserveRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcServer.Protos.ReserveRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcServer.Protos.ReserveReply> __Marshaller_provisioning_ReserveReply = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcServer.Protos.ReserveReply.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcServer.Protos.ActivateRequest> __Marshaller_provisioning_ActivateRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcServer.Protos.ActivateRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcServer.Protos.ActivateReply> __Marshaller_provisioning_ActivateReply = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcServer.Protos.ActivateReply.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcServer.Protos.DeactivateRequest> __Marshaller_provisioning_DeactivateRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcServer.Protos.DeactivateRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcServer.Protos.DeactivateReply> __Marshaller_provisioning_DeactivateReply = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcServer.Protos.DeactivateReply.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcServer.Protos.TerminateRequest> __Marshaller_provisioning_TerminateRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcServer.Protos.TerminateRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcServer.Protos.TerminateReply> __Marshaller_provisioning_TerminateReply = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcServer.Protos.TerminateReply.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcServer.Protos.FreeCoberturaRequest> __Marshaller_provisioning_FreeCoberturaRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcServer.Protos.FreeCoberturaRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcServer.Protos.FreeCoberturaReply> __Marshaller_provisioning_FreeCoberturaReply = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcServer.Protos.FreeCoberturaReply.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcServer.Protos.AllInfoRequest> __Marshaller_provisioning_AllInfoRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcServer.Protos.AllInfoRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcServer.Protos.AllInfoReply> __Marshaller_provisioning_AllInfoReply = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcServer.Protos.AllInfoReply.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcServer.Protos.GetUserRequest> __Marshaller_provisioning_GetUserRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcServer.Protos.GetUserRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcServer.Protos.GetUserReply> __Marshaller_provisioning_GetUserReply = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcServer.Protos.GetUserReply.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcServer.Protos.RegisterUserRequest> __Marshaller_provisioning_RegisterUserRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcServer.Protos.RegisterUserRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcServer.Protos.RegisterUserReply> __Marshaller_provisioning_RegisterUserReply = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcServer.Protos.RegisterUserReply.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::GrpcServer.Protos.ReserveRequest, global::GrpcServer.Protos.ReserveReply> __Method_Reserve = new grpc::Method<global::GrpcServer.Protos.ReserveRequest, global::GrpcServer.Protos.ReserveReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Reserve",
        __Marshaller_provisioning_ReserveRequest,
        __Marshaller_provisioning_ReserveReply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::GrpcServer.Protos.ActivateRequest, global::GrpcServer.Protos.ActivateReply> __Method_Activate = new grpc::Method<global::GrpcServer.Protos.ActivateRequest, global::GrpcServer.Protos.ActivateReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Activate",
        __Marshaller_provisioning_ActivateRequest,
        __Marshaller_provisioning_ActivateReply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::GrpcServer.Protos.DeactivateRequest, global::GrpcServer.Protos.DeactivateReply> __Method_Deactivate = new grpc::Method<global::GrpcServer.Protos.DeactivateRequest, global::GrpcServer.Protos.DeactivateReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Deactivate",
        __Marshaller_provisioning_DeactivateRequest,
        __Marshaller_provisioning_DeactivateReply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::GrpcServer.Protos.TerminateRequest, global::GrpcServer.Protos.TerminateReply> __Method_Terminate = new grpc::Method<global::GrpcServer.Protos.TerminateRequest, global::GrpcServer.Protos.TerminateReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Terminate",
        __Marshaller_provisioning_TerminateRequest,
        __Marshaller_provisioning_TerminateReply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::GrpcServer.Protos.FreeCoberturaRequest, global::GrpcServer.Protos.FreeCoberturaReply> __Method_FreeCobertura = new grpc::Method<global::GrpcServer.Protos.FreeCoberturaRequest, global::GrpcServer.Protos.FreeCoberturaReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "FreeCobertura",
        __Marshaller_provisioning_FreeCoberturaRequest,
        __Marshaller_provisioning_FreeCoberturaReply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::GrpcServer.Protos.AllInfoRequest, global::GrpcServer.Protos.AllInfoReply> __Method_AllInfo = new grpc::Method<global::GrpcServer.Protos.AllInfoRequest, global::GrpcServer.Protos.AllInfoReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "AllInfo",
        __Marshaller_provisioning_AllInfoRequest,
        __Marshaller_provisioning_AllInfoReply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::GrpcServer.Protos.GetUserRequest, global::GrpcServer.Protos.GetUserReply> __Method_GetUser = new grpc::Method<global::GrpcServer.Protos.GetUserRequest, global::GrpcServer.Protos.GetUserReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetUser",
        __Marshaller_provisioning_GetUserRequest,
        __Marshaller_provisioning_GetUserReply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::GrpcServer.Protos.RegisterUserRequest, global::GrpcServer.Protos.RegisterUserReply> __Method_RegisterUser = new grpc::Method<global::GrpcServer.Protos.RegisterUserRequest, global::GrpcServer.Protos.RegisterUserReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "RegisterUser",
        __Marshaller_provisioning_RegisterUserRequest,
        __Marshaller_provisioning_RegisterUserReply);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::GrpcServer.Protos.ProvisioningReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of Provisioning</summary>
    [grpc::BindServiceMethod(typeof(Provisioning), "BindService")]
    public abstract partial class ProvisioningBase
    {
      /// <summary>
      /// Define uma fun��o RPC chamada Reserve que recebe uma mensagem do tipo ReserveRequest e retorna uma mensagem do tipo ReserveReply.
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::GrpcServer.Protos.ReserveReply> Reserve(global::GrpcServer.Protos.ReserveRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      /// <summary>
      /// Similar � fun��o Reserve, mas para a opera��o Activate.
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::GrpcServer.Protos.ActivateReply> Activate(global::GrpcServer.Protos.ActivateRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      /// <summary>
      /// Similar � fun��o Reserve, mas para a opera��o Deactivate.
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::GrpcServer.Protos.DeactivateReply> Deactivate(global::GrpcServer.Protos.DeactivateRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::GrpcServer.Protos.TerminateReply> Terminate(global::GrpcServer.Protos.TerminateRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::GrpcServer.Protos.FreeCoberturaReply> FreeCobertura(global::GrpcServer.Protos.FreeCoberturaRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::GrpcServer.Protos.AllInfoReply> AllInfo(global::GrpcServer.Protos.AllInfoRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::GrpcServer.Protos.GetUserReply> GetUser(global::GrpcServer.Protos.GetUserRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::GrpcServer.Protos.RegisterUserReply> RegisterUser(global::GrpcServer.Protos.RegisterUserRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(ProvisioningBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_Reserve, serviceImpl.Reserve)
          .AddMethod(__Method_Activate, serviceImpl.Activate)
          .AddMethod(__Method_Deactivate, serviceImpl.Deactivate)
          .AddMethod(__Method_Terminate, serviceImpl.Terminate)
          .AddMethod(__Method_FreeCobertura, serviceImpl.FreeCobertura)
          .AddMethod(__Method_AllInfo, serviceImpl.AllInfo)
          .AddMethod(__Method_GetUser, serviceImpl.GetUser)
          .AddMethod(__Method_RegisterUser, serviceImpl.RegisterUser).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, ProvisioningBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_Reserve, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::GrpcServer.Protos.ReserveRequest, global::GrpcServer.Protos.ReserveReply>(serviceImpl.Reserve));
      serviceBinder.AddMethod(__Method_Activate, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::GrpcServer.Protos.ActivateRequest, global::GrpcServer.Protos.ActivateReply>(serviceImpl.Activate));
      serviceBinder.AddMethod(__Method_Deactivate, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::GrpcServer.Protos.DeactivateRequest, global::GrpcServer.Protos.DeactivateReply>(serviceImpl.Deactivate));
      serviceBinder.AddMethod(__Method_Terminate, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::GrpcServer.Protos.TerminateRequest, global::GrpcServer.Protos.TerminateReply>(serviceImpl.Terminate));
      serviceBinder.AddMethod(__Method_FreeCobertura, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::GrpcServer.Protos.FreeCoberturaRequest, global::GrpcServer.Protos.FreeCoberturaReply>(serviceImpl.FreeCobertura));
      serviceBinder.AddMethod(__Method_AllInfo, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::GrpcServer.Protos.AllInfoRequest, global::GrpcServer.Protos.AllInfoReply>(serviceImpl.AllInfo));
      serviceBinder.AddMethod(__Method_GetUser, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::GrpcServer.Protos.GetUserRequest, global::GrpcServer.Protos.GetUserReply>(serviceImpl.GetUser));
      serviceBinder.AddMethod(__Method_RegisterUser, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::GrpcServer.Protos.RegisterUserRequest, global::GrpcServer.Protos.RegisterUserReply>(serviceImpl.RegisterUser));
    }

  }
}
#endregion