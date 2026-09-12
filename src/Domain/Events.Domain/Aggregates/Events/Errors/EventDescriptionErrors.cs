using Events.Domain.Aggregates.Events.ValueObjects;
using Events.Domain.Shared;

namespace Events.Domain.Aggregates.Events.Errors;

public static class EventDescriptionErrors
{
    public static Error GreaterThanMaxLength =>
        new("EventDescription.GreaterThanMaxLength",
            $"Описание мероприятия больше максимальной длины в {Description.MaxLength} символ(-ов).");
}