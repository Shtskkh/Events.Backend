using Events.Domain.Aggregates.Events.ValueObjects;
using Events.Domain.Shared;

namespace Events.Domain.Aggregates.Events.Errors;

public static class EventTitleErrors
{
    public static Error GreaterThanMaxLength =>
        new("EventTitle.GreaterThanMaxLength",
            $"Название мероприятия больше максимальной длины в {Title.MaxLength} символ(-ов).");
}