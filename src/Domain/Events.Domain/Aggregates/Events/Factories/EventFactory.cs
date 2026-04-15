using Events.Domain.Aggregates.Events.Errors;
using Events.Domain.Aggregates.Events.ValueObjects;
using Events.Domain.Exceptions;
using Events.Domain.Shared.ValueObjects;

namespace Events.Domain.Aggregates.Events.Factories;

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
    /// <param name="locationId">ID локации.</param>
    /// <param name="placeId">ID помещения.</param>
    /// <param name="maxParticipants">Максимальное количество участников.</param>
    /// <param name="previewFilename">Название файла превью.</param>
    /// <param name="placeholderFilename">Название плейсхолдера превью.</param>
    /// <returns>Объект сущности мероприятия.</returns>
    public static Event Create(
        string title,
        string announcement,
        string description,
        DateTimeOffset startDateTime,
        DateTimeOffset endDateTime,
        EventType eventType,
        EventFormat eventFormat,
        Guid userId,
        bool needRegistration,
        int? locationId = null,
        int? placeId = null,
        int? maxParticipants = null,
        string? previewFilename = null,
        string? placeholderFilename = null)
    {
        ValidatePreview(previewFilename, placeholderFilename);
        ValidateRegistration(needRegistration, maxParticipants);
        ValidateBooking(eventFormat, locationId, placeId);

        var @event = new Event(
            Guid.NewGuid(),
            new Title(title),
            new Announcement(announcement),
            new Description(description),
            new DateTimeRange(startDateTime, endDateTime),
            eventType,
            eventFormat,
            userId,
            needRegistration);

        ApplyPreview(@event, previewFilename, placeholderFilename);

        if (maxParticipants.HasValue)
            @event.ChangeMaxParticipants(maxParticipants.Value);

        if (locationId.HasValue && placeId.HasValue)
            @event.Book(locationId.Value, placeId.Value);

        return @event;
    }

    private static void ValidatePreview(string? previewFilename, string? placeholderFilename)
    {
        if (string.IsNullOrWhiteSpace(previewFilename) && string.IsNullOrWhiteSpace(placeholderFilename))
            throw new DomainException(EventPreviewErrors.PlaceholderAndPreviewCannotBothBeEmpty);

        if (!string.IsNullOrWhiteSpace(previewFilename) && !string.IsNullOrWhiteSpace(placeholderFilename))
            throw new DomainException(EventPreviewErrors.PlaceholderAndPreviewCannotBothBeSet);
    }

    private static void ValidateRegistration(bool needRegistration, int? maxParticipants)
    {
        if (needRegistration && !maxParticipants.HasValue)
            throw new DomainException(EventParticipantErrors.MaxCountMustBeSet);
    }

    private static void ValidateBooking(EventFormat eventFormat, int? locationId, int? placeId)
    {
        if (eventFormat.Id != EventFormat.Online.Id && (!locationId.HasValue || !placeId.HasValue))
            throw new DomainException(EventBookingErrors.RequiredForOfflineAndHybrid);
    }

    private static void ApplyPreview(Event @event, string? previewFilename, string? placeholderFilename)
    {
        if (!string.IsNullOrWhiteSpace(previewFilename))
            @event.ChangePreview(previewFilename);
        else
            @event.ChangePlaceHolder(placeholderFilename!);
    }
}