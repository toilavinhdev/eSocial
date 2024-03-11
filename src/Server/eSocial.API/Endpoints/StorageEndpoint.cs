using eSocial.Application.Features.FeatureStorage.Commands;
using eSocial.Shared.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eSocial.API.Endpoints;

public class StorageEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/storage").WithTags("Storage");

        group.MapPost("/upload", async (
                IFormFile file,
                [FromForm] string? bucket,
                [FromServices] IMediator mediator
            ) => await mediator.Send(new UploadFileCommand{ File = file, Bucket = bucket }))
            .DisableAntiforgery();
    }
}