using eSocial.Shared.ValueObjects;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;

namespace eSocial.Shared.Extensions;

public static class StaticFileExtensions
{
    public static IApplicationBuilder UsePhysicalStaticFiles(this IApplicationBuilder app, StaticFileConfig config)
    {
        if (!Directory.Exists(config.Location)) Directory.CreateDirectory(config.Location);
        app.UseStaticFiles(new StaticFileOptions()
        {
            FileProvider = new PhysicalFileProvider(config.Location),
            RequestPath = new PathString(config.External)
        });
        return app;
    }
}