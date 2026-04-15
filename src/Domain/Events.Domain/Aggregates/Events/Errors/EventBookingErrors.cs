using Events.Domain.Shared;

namespace Events.Domain.Aggregates.Events.Errors;

public static class EventBookingErrors
{
    public static Error LocationIdLessOrEqualToZero => new("EventBooking.LocationIdLessOrEqualToZero",
        "ID локации не может быть меньше или равен нулю.");

    public static Error PlaceIdLessOrEqualToZero => new("EventBooking.PlaceIdLessOrEqualToZero",
        "ID помещения не может быть меньше или равен нулю.");

    public static Error NotAllowedForOnline => new("EventBooking.NotAllowedForOnline",
        "Нельзя бронировать аудитории для онлайн мероприятий.");

    public static Error RequiredForOfflineAndHybrid => new("EventBooking.RequiredForOfflineAndHybrid",
        "Бронирование помещения обязательно для офлайн или гибридных мероприятий.");

    public static Error TimeConflict(DateTimeOffset start, DateTimeOffset end)
    {
        return new Error("EventBooking.TimeConflict",
            $"На временной промежуток с {start.ToString()} по {end.ToString()} уже существует бронирование, выберите другое время.");
    }
}