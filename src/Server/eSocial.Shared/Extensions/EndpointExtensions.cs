using eSocial.Shared.ValueObjects;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace eSocial.Shared.Extensions;

public static class EndpointExtensions
{
    public static IServiceCollection AddEndpointDefinitions<TAssembly>(this IServiceCollection services)
    {
        var serviceDescriptors = typeof(TAssembly).Assembly
            .DefinedTypes
            .Where(type => type is { IsAbstract: false, IsInterface: false } && type.IsAssignableTo(typeof(IEndpoint)))
            .Select(type => ServiceDescriptor.Transient(typeof(IEndpoint), type))
            .ToArray();

        services.TryAddEnumerable(serviceDescriptors);

        return services;
    }
    
    public static WebApplication MapEndpointDefinitions(this WebApplication app, RouteGroupBuilder? routeGroupBuilder = null)
    {
        var endpoints = app.Services
            .GetRequiredService<IEnumerable<IEndpoint>>();

        var builder = routeGroupBuilder ?? (IEndpointRouteBuilder)app;

        foreach (var endpoint in endpoints)
        {
            endpoint.MapEndpoint(builder);
        }
        
        return app;
    }
}