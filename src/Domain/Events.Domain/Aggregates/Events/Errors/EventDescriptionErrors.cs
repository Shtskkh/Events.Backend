using Events.Domain.Shared;

namespace Events.Domain.Aggregates.Events.Errors;

public static class EventDescriptionErrors
{
    public static Error GreaterThanMaxLength(int max)
    {
        return new Error("EventDescription.GreaterThanMaxLength",
            $"Описание мероприятия больше максимальной длины в {max} символ(-ов).");
    }
}