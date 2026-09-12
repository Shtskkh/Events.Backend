using Events.Domain.Shared;

namespace Events.Domain.Aggregates.Events.Errors;

public static class EventTypeErrors
{
    public static Error NotFoundAny => new("EventType.NotFoundAny", "Типы мероприятий не найдены.");

    public static Error TitleGreaterThanMaxLenght =>
        new("EventType.TitleGreaterThanMaxLength",
            $"Название типа мероприятия больше максимальной длины в {EventType.MaxTitleLength} символ(-ов).");

    public static Error NotFoundById(int typeId)
    {
        return new Error("EventType.NotFoundById", $"Тип мероприятия с ID: {typeId} не найден.");
    }
}