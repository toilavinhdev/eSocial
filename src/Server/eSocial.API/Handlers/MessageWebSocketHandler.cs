using System.Net.WebSockets;
using eSocial.Shared.WebSockets;

namespace eSocial.API.Handlers;

public class MessageWebSocketHandler(WebSocketConnectionManager webSocketConnectionManager, 
    ILogger<MessageWebSocketHandler> logger) : WebSocketHandler(webSocketConnectionManager)
{
    public override Task ReceiveAsync(WebSocket socket, WebSocketReceiveResult result, byte[] buffer)
    {
        throw new NotImplementedException();
    }

    public override Task OnConnected(string id, WebSocket socket)
    {
        base.OnConnected(id, socket);
        logger.LogInformation($"Socket {id} is connected. Total {WebSocketConnectionManager.GetAllSockets().Count} socket currently connected");
        return Task.CompletedTask;
    }

    public override async Task OnDisconnected(string id, WebSocketReceiveResult result)
    {
        await base.OnDisconnected(id, result);
        logger.LogInformation($"Socket {id} is disconnected. Total {WebSocketConnectionManager.GetAllSockets().Count} socket currently connected");
    }
}