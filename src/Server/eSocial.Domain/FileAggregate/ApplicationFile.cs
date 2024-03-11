using eSocial.Shared.ValueObjects;

namespace eSocial.Domain.FileAggregate;

public class ApplicationFile : TrackingDocument
{
    public string SourceName { get; set; } = default!;

    public string FileName { get; set; } = default!;

    public string ContentType { get; set; } = default!;
    
    public long Size { get; set; }

    public string Url { get; set; } = default!;
}