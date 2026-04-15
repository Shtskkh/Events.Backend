using Events.Domain.Shared;

namespace Events.Domain.Aggregates.Events.Errors;

public static class EventTitleErrors
{
    public static Error GreaterThanMaxLength(int max)
    {
        return new Error("EventTitle.GreaterThanMaxLength",
            $"Название мероприятия больше максимальной длины в {max} символ(-ов).");
    }
}