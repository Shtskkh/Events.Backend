using Events.Contracts.Files;
using Events.Contracts.Places;
using Events.Contracts.Tags;

namespace Events.Contracts.Events;

/// <summary>
///     Полная информация о мероприятии.
/// </summary>
public sealed record EventDto
{
    /// <summary>
    ///     Идентификатор мероприятия.
    /// </summary>
    public Guid Id { get; init; }

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
    ///     Флаг необходимости регистрации.
    /// </summary>
    public bool NeedsRegistration { get; init; }

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

    /// <summary>
    ///     Создатель.
    /// </summary>
    public Guid UserId { get; init; }

    /// <summary>
    ///     Информация о помещении.
    /// </summary>
    public BookedPlaceDto? PlaceInfo { get; set; }

    /// <summary>
    ///     Тэги.
    /// </summary>
    public IReadOnlyCollection<TagDto>? Tags { get; init; }
}