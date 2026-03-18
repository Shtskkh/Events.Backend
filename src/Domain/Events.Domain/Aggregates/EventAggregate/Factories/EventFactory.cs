using Events.Domain.Aggregates.EventAggregate.ValueObjects;
using Events.Domain.Exceptions;
using Events.Domain.Shared;

namespace Events.Domain.Aggregates.EventAggregate.Factories;

/// <summary>
///     Фабрика мероприятия.
/// </summary>
public static class EventFactory
{
    /// <summary>
    ///     Создать мероприятие.
    /// </summary>
    /// <param name="title">Название.</param>
    /// <param name="announcement">Анонс (краткое описание).</param>
    /// <param name="description">Описание.</param>
    /// <param name="startDateTime">Дата и время начала.</param>
    /// <param name="endDateTime">Дата и время окончания.</param>
    /// <param name="eventType">Тип мероприятия.</param>
    /// <param name="eventFormat">Формат мероприятия.</param>
    /// <param name="needRegistration">Необходимость регистрации.</param>
    /// <param name="userId">ID пользователя.</param>
    /// <param name="maxParticipants">Максимальное количество участников.</param>
    /// <param name="previewFilename">Название файла превью.</param>
    /// <param name="placeholderFilename">Название плейсхолдера превью.</param>
    /// <returns>Объект сущности пользователя.</returns>
    public static Event Create(string title, string announcement, string description, DateTimeOffset startDateTime,
        DateTimeOffset endDateTime, EventType eventType, EventFormat eventFormat, Guid userId, bool needRegistration,
        int? placeId = null, int? maxParticipants = null, string? previewFilename = null,
        string? placeholderFilename = null)
    {
        var id = Guid.NewGuid();
        var titleVo = new EventTitle(title);
        var announcementVo = new EventAnnouncement(announcement);
        var descriptionVo = new EventDescription(description);

        if (string.IsNullOrWhiteSpace(previewFilename) && string.IsNullOrWhiteSpace(placeholderFilename))
            throw new DomainException(DomainErrorMessages.Event.Preview.PlaceholderAndPreviewCannotBothBeEmpty);

        if (!string.IsNullOrWhiteSpace(previewFilename) && !string.IsNullOrWhiteSpace(placeholderFilename))
            throw new DomainException(DomainErrorMessages.Event.Preview.PlaceholderAndPreviewCannotBothBeSet);

        if (needRegistration && !maxParticipants.HasValue)
            throw new DomainException(DomainErrorMessages.Event.Participant.MaxCountMustBeSet);

        if (eventFormat.Id != EventFormat.Online.Id && !placeId.HasValue)
            throw new DomainException(DomainErrorMessages.Event.Booking.RequiredForOffline);

        var @event = new Event(id, titleVo, announcementVo, descriptionVo,
            startDateTime, endDateTime, eventType, eventFormat, userId, needRegistration);

        if (!string.IsNullOrWhiteSpace(previewFilename))
            @event.ChangePreview(previewFilename);
        else
            @event.ChangePlaceHolder(placeholderFilename!);

        if (maxParticipants.HasValue)
            @event.ChangeMaxParticipants(maxParticipants.Value);

        if (placeId.HasValue)
            @event.Book(placeId.Value);

        return @event;
    }
}