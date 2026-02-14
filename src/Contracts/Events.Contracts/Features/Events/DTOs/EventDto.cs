namespace Events.Contracts.Features.Events.DTOs;

/// <summary>
///     Полная информация о мероприятии.
/// </summary>
public class EventDto
{
    /// <summary>
    ///     Название мероприятия.
    /// </summary>
    public string Title { get; init; } = null!;

    /// <summary>
    ///     Описание мероприятия.
    /// </summary>
    public string Description { get; init; } = null!;

    /// <summary>
    ///     Тип мероприятия.
    /// </summary>
    public string Type { get; init; } = null!;

    /// <summary>
    ///     Формат мероприятия.
    /// </summary>
    public string Format { get; init; } = null!;

    /// <summary>
    ///     Дата и время начала мероприятия.
    /// </summary>
    public DateTimeOffset StartDateTime { get; init; }

    /// <summary>
    ///     Дата и время окончания мероприятия.
    /// </summary>
    public DateTimeOffset EndDateTime { get; init; }

    /// <summary>
    ///     Ссылка на загрузку превью мероприятия.
    /// </summary>
    public Uri PreviewDownloadLink { get; set; } = null!;
}