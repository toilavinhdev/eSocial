using eSocial.Shared.ValueObjects;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace eSocial.Shared.Extensions;

public static class WebBuilderExtensions
{
    public static void SetupEnvironment(this WebApplicationBuilder builder, string? external, out AppSettings appSettings)
    {
        appSettings = new AppSettings();
        var environment = builder.Environment;
        var json = $"appsettings.{environment.EnvironmentName}.json";
        var path = !string.IsNullOrEmpty(external) ? Path.Combine(external, json) : json;
        
        new ConfigurationBuilder()
            .SetBasePath(environment.ContentRootPath)
            .AddJsonFile(path)
            .AddEnvironmentVariables()
            .Build()
            .Bind(appSettings);

        builder.Services.AddSingleton(appSettings);
    }
    
    public static void SetupSerilog(this WebApplicationBuilder builder)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Console()
            .CreateLogger();
        builder.Host.UseSerilog();
        builder.Logging.ClearProviders();
        builder.Logging.AddSerilog();
    }
}