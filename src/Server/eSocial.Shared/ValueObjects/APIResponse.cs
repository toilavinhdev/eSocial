using System.Text.Json.Serialization;

namespace eSocial.Shared.ValueObjects;

public class APIResponse
{
    public bool Success { get; set; }
    
    public int StatusCode { get; set; }
    
    public string? Message { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public dynamic? Errors { get; set; }
}

public class APIResponse<T> : APIResponse
{
    public T Data { get; set; } = default!;
}