using System.Text.Json.Serialization;

namespace eSocial.Shared.ValueObjects;

public class APIResponse
{
    public bool Success { get; set; }
    
    public int StatusCode { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Message { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public dynamic? Errors { get; set; }

    public APIResponse IsSuccess(string? message = null) => new()
    {
        Success = true,
        StatusCode = 200,
        Message = message
    };
}

public class APIResponse<T> : APIResponse
{
    public T Data { get; set; } = default!;
    
    public APIResponse<T> IsSuccess(T data, string? message = null) => new()
    {
        Success = true,
        StatusCode = 200,
        Message = message,
        Data = data
    };
}