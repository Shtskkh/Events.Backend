using Events.Domain.Shared;
using Events.Domain.Shared.ValueObjects;

namespace Events.Domain.Aggregates.Events.Errors;

public static class DateTimeRangeErrors
{
    public static Error StartLaterThanEnd => new("DateTimeRange.StartLaterThanEnd",
        "Дата и время начала мероприятия не может быть равно или позднее дате и времени окончания");

    public static Error DurationGreaterThanMax =>
        new("DateTimeRange.DurationGreaterThanMax",
            $"Длина мероприятия больше максимальной длины в {DateTimeRange.MaxDurationInDays} день(-ей).");
}