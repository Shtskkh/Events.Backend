using Events.Contracts.Files;
using Events.Contracts.Tags;

namespace Events.Contracts.Events;

/// <summary>
///     Краткая информация о мероприятии.
/// </summary>
public sealed record ShortEventDto
{
    /// <summary>
    ///     ID.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    ///     Название.
    /// </summary>
    public string Title { get; init; } = null!;

    /// <summary>
    ///     Анонс (краткое описание).
    /// </summary>
    public string Announcement { get; init; } = null!;

    /// <summary>
    ///     Тип.
    /// </summary>
    public string Type { get; init; } = null!;

    /// <summary>
    ///     Формат.
    /// </summary>
    public string Format { get; init; } = null!;

    /// <summary>
    ///     Дата и время начала.
    /// </summary>
    public DateTimeOffset StartDateTime { get; init; }

    /// <summary>
    ///     Дата и время окончания.
    /// </summary>
    public DateTimeOffset EndDateTime { get; init; }

    /// <summary>
    ///     Информация о превью.
    /// </summary>
    public S3FileDto PreviewInfo { get; init; } = null!;

    /// <summary>
    ///     Создатель.
    /// </summary>
    public Guid UserId { get; init; }

    /// <summary>
    ///     Тэги.
    /// </summary>
    public IReadOnlyCollection<TagDto>? Tags { get; init; }
}