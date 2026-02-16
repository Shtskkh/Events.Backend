namespace Events.Domain.Aggregates.EventAggregate.Factories;

/// <summary>
///     Фабрика создания мероприятия.
/// </summary>
public interface IEventFactory
{
    /// <summary>
    ///     Создание нового мероприятия.
    /// </summary>
    /// <param name="title">Название мероприятие.</param>
    /// <param name="announcement">Анонс мероприятия.</param>
    /// <param name="description">Описание мероприятия.</param>
    /// <param name="startDateTime">Дата и время начала мероприятия.</param>
    /// <param name="endDateTime">Дата и время окончания мероприятия.</param>
    /// <param name="eventType">Тип мероприятия.</param>
    /// <param name="eventFormat">Формат мероприятия.</param>
    /// <param name="needsRegistration">Флаг необходимости регистрации.</param>
    /// <param name="previewFilename">Название файла превью.</param>
    /// <param name="placeholderFilename">Название файла плейсхолдера превью.</param>
    /// <returns>Объект созданного мероприятия.</returns>
    Event Create(
        string title,
        string announcement,
        string description,
        DateTimeOffset startDateTime,
        DateTimeOffset endDateTime,
        EventType eventType,
        EventFormat eventFormat,
        bool needsRegistration,
        Guid? previewFilename = null,
        string? placeholderFilename = null
    );
}