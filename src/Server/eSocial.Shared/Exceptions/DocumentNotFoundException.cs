using System.Diagnostics.CodeAnalysis;
using eSocial.Shared.ValueObjects;

namespace eSocial.Shared.Exceptions;

public class DocumentNotFoundException<T>(string? parameter) 
    : BadRequestException($"Document ${typeof(T).Name} ${parameter} was not found!") where T : Document
{
    public static void ThrowIfNotFound([NotNull] object? obj, string? parameter = null)
    {
        if (obj is not null) return;
        throw new DocumentNotFoundException<T>(parameter);
    }
}