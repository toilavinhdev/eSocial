using System.Net.WebSockets;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace eSocial.Shared.WebSockets;

public class WebSocketMiddleware(RequestDelegate next, WebSocketHandler webSocketHandler)
{
    public async Task InvokeAsync(HttpContext context, ILogger<WebSocketMiddleware> logger)
    {
        if (!context.WebSockets.IsWebSocketRequest)
        {
            await next(context);
            logger.LogError("Not a websocket connection!");
            return;
        }

        var socket = await context.WebSockets.AcceptWebSocketAsync();
        var socketId = context.Request.Query["id"].ToString();
        if (string.IsNullOrEmpty(socketId)) socketId = Guid.NewGuid().ToString();
        await webSocketHandler.OnConnected(socketId, socket);
        
        await Receive(socket, HandleMessage);
        return;

        async void HandleMessage(WebSocketReceiveResult result, byte[] buffer)
        {
            switch (result.MessageType)
            {
                case WebSocketMessageType.Text:
                    await webSocketHandler.ReceiveAsync(socket, result, buffer);
                    break;
                case WebSocketMessageType.Close:
                    await webSocketHandler.OnDisconnected(socketId, result);
                    break;
                case WebSocketMessageType.Binary:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(result.MessageType.ToString());
            }
        }
    }

    private static async Task Receive(WebSocket socket, Action<WebSocketReceiveResult, byte[]> handleMessage)
    {
        var buffer = new byte[1024 * 4];
        
        // While open websocket connect
        while (socket.State == WebSocketState.Open)
        {
            var result = await socket.ReceiveAsync(
                buffer: new ArraySegment<byte>(buffer),
                cancellationToken: CancellationToken.None);
            handleMessage(result, buffer);
        }
    }
}