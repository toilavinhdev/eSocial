using System.Net.WebSockets;
using eSocial.Application.Features.FeatureMessage.Commands;
using eSocial.Shared.Extensions;
using eSocial.Shared.WebSockets;
using MediatR;

namespace eSocial.API.WebSockets;

public class ChatWebSocketHandler(WebSocketConnectionManager webSocketConnectionManager, 
    IServiceProvider serviceProvider,
    ILogger<ChatWebSocketHandler> logger) : WebSocketHandler(webSocketConnectionManager)
{
    public override Task OnConnected(string id, WebSocket socket)
    {
        base.OnConnected(id, socket);
        logger.LogInformation($"[{nameof(ChatWebSocketHandler)}] Socket {id} connected. " +
                              $"Total {WebSocketConnectionManager.GetAllSockets().Count} socket currently connected");
        return Task.CompletedTask;
    }

    public override async Task OnDisconnected(string id, WebSocketReceiveResult result)
    {
        await base.OnDisconnected(id, result);
        logger.LogInformation($"[{nameof(ChatWebSocketHandler)}] Socket {id} disconnected. " +
                              $"Total {WebSocketConnectionManager.GetAllSockets().Count} socket currently connected");
    }

    public override async Task ReceiveAsync(WebSocket socket, WebSocketReceiveResult result, byte[] buffer)
    {
        var receiveData = BufferToString(result, buffer).ToObject<CreateMessageCommand>();
        var scope = serviceProvider.CreateScope();
        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
        
        var document = await mediator.Send(receiveData);
    }
}