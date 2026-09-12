using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Events.Contracts.Events;

/// <summary>
///     Форма создания мероприятия.
/// </summary>
public sealed record CreateEventDto
{
    /// <summary>
    ///     ID создателя.
    /// </summary>
    public required Guid UserId { get; init; }

    /// <summary>
    ///     Название.
    /// </summary>
    [MaxLength(Domain.Aggregates.Events.ValueObjects.Title.MaxLength)]
    public required string Title { get; init; }

    /// <summary>
    ///     Анонс.
    /// </summary>
    [MaxLength(Domain.Aggregates.Events.ValueObjects.Announcement.MaxLength)]
    public required string Announcement { get; init; }

    /// <summary>
    ///     Описание.
    /// </summary>
    [MaxLength(Domain.Aggregates.Events.ValueObjects.Description.MaxLength)]
    public required string Description { get; init; }

    /// <summary>
    ///     Дата и время начала.
    /// </summary>
    public required DateTimeOffset StartDateTime { get; init; }

    /// <summary>
    ///     Дата и время окончания.
    /// </summary>
    public required DateTimeOffset EndDateTime { get; init; }

    /// <summary>
    ///     Флаг необходимости регистрации.
    /// </summary>
    public required bool NeedsRegistration { get; init; }

    /// <summary>
    ///     Максимальное число участников (при наличии регистрации).
    /// </summary>
    public int? MaxParticipants { get; init; }

    /// <summary>
    ///     ID типа.
    /// </summary>
    public required int EventTypeId { get; init; }

    /// <summary>
    ///     ID формата.
    /// </summary>
    public required int EventFormatId { get; init; }

    /// <summary>
    ///     Превью изображения для мероприятия (если не указан плейсхолдер).
    /// </summary>
    public IFormFile? Preview { get; init; }

    /// <summary>
    ///     Имя плейсхолдера файла для превью мероприятия (если не передано превью).
    /// </summary>
    public string? Placeholder { get; init; }

    /// <summary>
    ///     ID локации (для онлайн и гибридных).
    /// </summary>
    public int? LocationId { get; init; }

    /// <summary>
    ///     ID помещения в локации (для онлайн и гибридных).
    /// </summary>
    public int? PlaceId { get; init; }

    /// <summary>
    ///     Коллекция ID тэгов (необязательно).
    /// </summary>
    public IReadOnlyCollection<int>? TagsIds { get; init; }
}