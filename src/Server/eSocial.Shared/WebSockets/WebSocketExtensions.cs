using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace eSocial.Shared.WebSockets;

public static class WebSocketExtensions
{
    public static IServiceCollection AddWebSocketHandlers<TAssembly>(this IServiceCollection services)
    {
        services.AddSingleton<WebSocketConnectionManager>();
        
        var exportedType = typeof(TAssembly).Assembly.ExportedTypes;
        exportedType = exportedType.Where(x => x.GetTypeInfo().BaseType == typeof(WebSocketHandler));

        foreach (var type in exportedType)
        {
            services.AddSingleton(type);
        }
        
        return services;
    }
    
    
    public static WebApplication MapWebSocketHandler<THandler>(this WebApplication app, PathString path) where THandler : WebSocketHandler
    {
        var handler = app.Services.GetService<THandler>();
        app.Map(path, builder => builder.UseMiddleware<WebSocketMiddleware>(handler));
        return app;
    }
}