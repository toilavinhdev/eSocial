using eSocial.Application;
using eSocial.Application.Behaviors;
using eSocial.Infrastructure;
using eSocial.Shared.Extensions;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);
builder.SetupEnvironment("AppSettings", out var appSettings);
builder.SetupSerilog();

var services = builder.Services;
services.AddCors();
services.AddDefinedEndpoints<Program>();
services.AddSwaggerDocument();
services.AddHttpContextAccessor();
services.AddMediatR(cfg =>
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
app.UseHttpsRedirection();
app.UsePhysicalStaticFiles(appSettings.StaticFileConfig);
app.MapDefinedEndpoints();

app.MapGet("Ping", () => "Pong");

app.Run();