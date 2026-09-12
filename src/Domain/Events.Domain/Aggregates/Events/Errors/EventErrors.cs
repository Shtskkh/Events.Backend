using Events.Domain.Shared;

namespace Events.Domain.Aggregates.Events.Errors;

public static class EventErrors
{
    public static Error NotFoundByFilter => new("Event.NotFoundByFilter", "Мероприятия по фильтру не найдены.");

    public static Error NotFoundById(Guid eventId)
    {
        return new Error("Event.NotFoundById", $"Мероприятие с ID: {eventId} не найдено.");
    }

    public static Error TagNotFoundById(int tagId)
    {
        return new Error("Event.TagNotFoundById", $"Тэг с ID: {tagId} в данном мероприятии не найден.");
    }
}