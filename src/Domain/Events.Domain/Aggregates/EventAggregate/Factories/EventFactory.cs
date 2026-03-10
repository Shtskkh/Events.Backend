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
    /// <param name="previewFilename">Название файла превью.</param>
    /// <param name="placeholderFilename">Название плейсхолдера превью.</param>
    /// <returns>Объект сущности пользователя.</returns>
    public static Event Create(string title, string announcement, string description, DateTimeOffset startDateTime,
        DateTimeOffset endDateTime, EventType eventType, EventFormat eventFormat, bool needRegistration,
        Guid userId, string? previewFilename = null, string? placeholderFilename = null)
    {
        var id = Guid.NewGuid();
        var titleVo = new EventTitle(title);
        var announcementVo = new EventAnnouncement(announcement);
        var descriptionVo = new EventDescription(description);

        if (string.IsNullOrWhiteSpace(previewFilename) && string.IsNullOrWhiteSpace(placeholderFilename))
            throw new DomainException(DomainErrorMessages.Event.Preview.PlaceholderAndPreviewCannotBothBeSet);

        if (!string.IsNullOrWhiteSpace(previewFilename) && !string.IsNullOrWhiteSpace(placeholderFilename))
            throw new DomainException(DomainErrorMessages.Event.Preview.PlaceholderAndPreviewCannotBothBeEmpty);

        return new Event(
            id,
            titleVo,
            announcementVo,
            descriptionVo,
            startDateTime,
            endDateTime,
            eventType,
            eventFormat,
            userId,
            needRegistration,
            previewFilename,
            placeholderFilename
        );
    }
}