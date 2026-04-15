using Events.Domain.Shared;

namespace Events.Domain.Aggregates.Events.Errors;

public static class DateTimeRangeErrors
{
    public static Error StartLaterThanEnd => new("DateTimeRange.StartLaterThanEnd",
        "Дата и время начала мероприятия не может быть равно или позднее дате и времени окончания");

    public static Error DurationGreaterThanMax(int max)
    {
        return new Error("DateTimeRange.DurationGreaterThanMax",
            $"Длина мероприятия больше максимальной длины в {max} день(-ей).");
    }
}