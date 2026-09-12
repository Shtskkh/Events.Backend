using Microsoft.AspNetCore.Http;

namespace Events.Contracts.Photos;

public sealed record PhotoEntryDto
{
    /// <summary>
    ///     GUID уже существующего фото (если это не новый файл).
    /// </summary>
    public string? ExistingFilename { get; init; }

    /// <summary>
    ///     Новый файл (если загружается впервые).
    /// </summary>
    public IFormFile? NewFile { get; init; }
}