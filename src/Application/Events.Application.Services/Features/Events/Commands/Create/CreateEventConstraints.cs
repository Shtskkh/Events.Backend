using System.Net.Mime;

namespace Events.Application.Services.Features.Events.Commands.Create;

/// <summary>
///     Константы создания мероприятия.
/// </summary>
public static class CreateEventConstraints
{
    /// <summary>
    ///     Максимальный размер превью (5 МБ).
    /// </summary>
    public const int MaxSize = 5 * 1024 * 1024;

    /// <summary>
    ///     Разрешённые типы файлов превью.
    /// </summary>
    public static readonly string[] AllowedMimeTypes =
        [MediaTypeNames.Image.Jpeg, MediaTypeNames.Image.Png, MediaTypeNames.Image.Webp];
}