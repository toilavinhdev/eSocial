using System.Net.WebSockets;
using eSocial.Shared.WebSockets;

namespace eSocial.API.WebSockets;

public class NotificationWebSocketHandler(WebSocketConnectionManager webSocketConnectionManager) : WebSocketHandler(webSocketConnectionManager)
{
    public override async Task ReceiveAsync(WebSocket socket, WebSocketReceiveResult result, byte[] buffer)
    {
        throw new NotImplementedException();
    }
}