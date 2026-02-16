namespace Events.Contracts.Features.Events.DTOs;

/// <summary>
///     Плейсхолдер мероприятия.
/// </summary>
public class EventPlaceholderDto
{
    /// <summary>
    ///     Название плейсхолдера.
    /// </summary>
    public string Filename { get; init; }

    /// <summary>
    ///     Ссылка на скачивание плейсхолдера.
    /// </summary>
    public Uri DownloadLink { get; init; }
}