using Events.Contracts.Features.Files;

namespace Events.Contracts.Features.Events.DTOs;

/// <summary>
///     Краткая информация о мероприятии.
/// </summary>
public class ShortEventDto
{
    /// <summary>
    ///     ID мероприятия.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    ///     Название мероприятия.
    /// </summary>
    public string Title { get; init; } = null!;

    /// <summary>
    ///     Анонс (краткое описание) мероприятия.
    /// </summary>
    public string Announcement { get; init; } = null!;

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
    ///     Информация о превью мероприятия.
    /// </summary>
    public S3FileDto PreviewInfo { get; init; } = null!;
}