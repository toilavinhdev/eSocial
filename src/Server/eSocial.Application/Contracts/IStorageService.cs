using eSocial.Shared.Services;
using Microsoft.AspNetCore.Http;

namespace eSocial.Application.Contracts;

public interface IStorageService : IBaseService
{
    Task<string> SaveAsync(IFormFile file, string fileName, string? bucket = null, CancellationToken cancellationToken = new());
}