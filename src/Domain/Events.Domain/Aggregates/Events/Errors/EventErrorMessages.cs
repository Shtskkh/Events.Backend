namespace Events.Domain.Aggregates.Events.Errors;

/// <summary>
///     Ошибки мероприятия.
/// </summary>
public static class EventErrorMessages
{
    public const string NotFoundByFilter = "Мероприятия по фильтру не найдены.";

    public static string NotFoundById(Guid eventId)
    {
        return $"Мероприятие с ID: {eventId} не найдено.";
    }
}