using eSocial.Application.Contracts;
using eSocial.Domain.FileAggregate;
using eSocial.Shared.Mongo;
using eSocial.Shared.Services;
using eSocial.Shared.ValueObjects;
using Microsoft.AspNetCore.Http;
using MongoDB.Driver;

namespace eSocial.Infrastructure.Services;

public class StorageService(AppSettings appSettings, IHttpContextAccessor httpContextAccessor, 
    IMongoContext mongoContext) : BaseService(httpContextAccessor), IStorageService
{
    public async Task<string> SaveAsync(IFormFile file, string fileName, string? bucket = null, CancellationToken cancellationToken = new())
    {
        var root = appSettings.StaticFileConfig.Location;

        root = string.IsNullOrEmpty(bucket) ? root : InitialBucket(Path.Combine(root, bucket));

        var fullPath = Path.Combine(root, fileName);

        await using var stream = new FileStream(fullPath, FileMode.Create);
        await file.CopyToAsync(stream, cancellationToken);

        var url = GetFileUrl(fileName, bucket, appSettings.StaticFileConfig.External);
        
        var document = new ApplicationFile()
        {
            SourceName = file.Name,
            FileName = fileName,
            Url = url,
            ContentType = file.ContentType,
            Size = file.Length
        };
        document.MarkCreated(GetUserClaimValue()?.Email);

        await mongoContext.Collection<ApplicationFile>().InsertOneAsync(document, new InsertOneOptions(), cancellationToken);

        return url;
    }

    private string GetFileUrl(string fileName, string? bucket = null, string? external = null)
    {
        var raw = appSettings.Host;
        if (!string.IsNullOrEmpty(external)) raw = $"{raw}{external}";
        if (!string.IsNullOrEmpty(bucket))
        {
            if (bucket.StartsWith('/')) bucket = bucket[1..];
            raw = $"{raw}/{bucket}";
        }
        raw = $"{raw}/{fileName}";
        return raw;
    }
    
    private string InitialBucket(string path)
    {
        if (!Directory.Exists(path)) Directory.CreateDirectory(path);
        return path;
    }
}