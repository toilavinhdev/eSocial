using Newtonsoft.Json;

namespace eSocial.Shared.Extensions;

public static class JsonExtensions
{
    public static string ToJson<T>(this T input)
    {
        return JsonConvert.SerializeObject(input);
    }
    
    public static T ToObject<T>(this string input)
    {
        return string.IsNullOrEmpty(input) ? default! : JsonConvert.DeserializeObject<T>(input)!;
    }
}