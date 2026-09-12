using Events.Domain.Shared;

namespace Events.Domain.Aggregates.Events.Errors;

public static class EventFormatErrors
{
    public static Error NotFoundAny => new("EventFormat.NotFoundAny", "Форматы мероприятий не найдены.");

    public static Error NotFoundById(int formatId)
    {
        return new Error("EventFormat.NotFoundById", $"Формат мероприятия с ID: {formatId} не найден.");
    }
}