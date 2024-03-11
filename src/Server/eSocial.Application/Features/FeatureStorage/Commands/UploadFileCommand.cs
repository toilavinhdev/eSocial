using eSocial.Application.Contracts;
using eSocial.Shared.Mediator;
using eSocial.Shared.ValueObjects;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace eSocial.Application.Features.FeatureStorage.Commands;

public class UploadFileCommand : IAPIRequest<string>
{
    public IFormFile File { get; set; } = default!;
    
    public string? Bucket { get; set; }
}

public class UploadFileCommandValidator : AbstractValidator<UploadFileCommand>
{
    public UploadFileCommandValidator()
    {
        RuleFor(x => x.File).NotEmpty();
    }
}

public class UploadFileCommandHandler(IStorageService storageService) : IAPIRequestHandler<UploadFileCommand, string>
{
    public async Task<APIResponse<string>> Handle(UploadFileCommand request, CancellationToken cancellationToken)
    {
        var fileName = $"{Guid.NewGuid().ToString("N").ToLower()}{Path.GetExtension(request.File.FileName)}";

        var url = await storageService.SaveAsync(request.File, fileName, request.Bucket, cancellationToken);

        return new APIResponse<string>().IsSuccess(url, "Tải lên thành công");
    }
}