using eSocial.Application;
using eSocial.Infrastructure;
using eSocial.Shared.Extensions;
using eSocial.Shared.Mediator;
using eSocial.Shared.Security;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);
builder.SetupEnvironment("AppSettings", out var appSettings);
builder.SetupSerilog();

var services = builder.Services;
services.AddCors();
services.AddJWTBearerAuth(appSettings.JWTConfig);
services.AddAuthorization();
services.AddEndpointDefinitions<Program>();
services.AddSwaggerDocument();
services.AddHttpContextAccessor();
services.AddMediatR(
    cfg =>
    {
        cfg.RegisterServicesFromAssembly(AssemblyReference.Assembly);
        cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
    });
services.AddValidatorsFromAssembly(AssemblyReference.Assembly);
services.AddAutoMapper(AssemblyReference.Assembly);
services.AddServiceCollections();

var app = builder.Build();
app.UseDefaultExceptionHandler();
app.UseCors(b => b.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.UseSwaggerDocument();
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.UsePhysicalStaticFiles(appSettings.StaticFileConfig);
app.MapEndpointDefinitions();

app.MapGet("Ping", () => "Pong");

app.Run();