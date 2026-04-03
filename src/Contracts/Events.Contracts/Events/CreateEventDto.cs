using System.ComponentModel.DataAnnotations;
using Events.Domain.Aggregates.EventAggregate.Constraints;
using Microsoft.AspNetCore.Http;

namespace Events.Contracts.Events;

/// <summary>
///     Создание мероприятия.
/// </summary>
public class CreateEventDto
{
    /// <summary>
    ///     ID пользователя, создающего мероприятие.
    /// </summary>
    public required Guid UserId { get; init; }

    /// <summary>
    ///     Название мероприятия.
    /// </summary>
    [MinLength(1)]
    [MaxLength(EventConstraints.Title.MaxLength)]
    public required string Title { get; init; }

    /// <summary>
    ///     Анонс мероприятия.
    /// </summary>
    [MinLength(1)]
    [MaxLength(EventConstraints.Announcement.MaxLength)]
    public required string Announcement { get; init; }

    /// <summary>
    ///     Описание мероприятия.
    /// </summary>
    [MinLength(1)]
    [MaxLength(EventConstraints.Description.MaxLength)]
    public required string Description { get; init; }

    /// <summary>
    ///     Дата и время начала мероприятия.
    /// </summary>
    public required DateTimeOffset StartDateTime { get; init; }

    /// <summary>
    ///     Дата и время окончания мероприятия.
    /// </summary>
    public required DateTimeOffset EndDateTime { get; init; }

    /// <summary>
    ///     Флаг необходимости регистрации.
    /// </summary>
    public required bool NeedsRegistration { get; init; }

    /// <summary>
    ///     Максимальное число участников.
    /// </summary>
    public int? MaxParticipants { get; init; }

    /// <summary>
    ///     ID типа мероприятия.
    /// </summary>
    public required int EventTypeId { get; init; }

    /// <summary>
    ///     Формат мероприятия.
    /// </summary>
    public required int EventFormatId { get; init; }

    /// <summary>
    ///     Превью изображения для мероприятия.
    /// </summary>
    public IFormFile? Preview { get; init; }

    /// <summary>
    ///     Имя плейсхолдера файла для превью мероприятия.
    /// </summary>
    public string? Placeholder { get; init; }

    /// <summary>
    ///     ID помещения.
    /// </summary>
    public int? PlaceId { get; init; }
}