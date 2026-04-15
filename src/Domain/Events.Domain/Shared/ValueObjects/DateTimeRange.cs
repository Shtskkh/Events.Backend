using Events.Domain.Aggregates.Events.Errors;
using Events.Domain.Exceptions;

namespace Events.Domain.Shared.ValueObjects;

/// <summary>
///     Диапазона дат мероприятия.
/// </summary>
public class DateTimeRange : ValueObject
{
    public const int MaxDurationInDays = 31;

    private DateTimeRange()
    {
    }

    public DateTimeRange(DateTimeOffset start, DateTimeOffset end)
    {
        if (start >= end)
            throw new DomainException(DateTimeRangeErrors.StartLaterThanEnd);

        if (end - start > TimeSpan.FromDays(MaxDurationInDays))
            throw new DomainException(DateTimeRangeErrors.DurationGreaterThanMax(MaxDurationInDays));

        StartDateTime = start.ToUniversalTime();
        EndDateTime = end.ToUniversalTime();
    }

    /// <summary>
    ///     Дата и время начала мероприятия в UTC.
    /// </summary>
    public DateTimeOffset StartDateTime { get; }

    /// <summary>
    ///     Дата и время окончания мероприятия в UTC.
    /// </summary>
    public DateTimeOffset EndDateTime { get; }

    /// <summary>
    ///     Создать новый диапазон со сдвинутым началом.
    /// </summary>
    /// <param name="newStart">Новая дата начала.</param>
    public DateTimeRange WithStart(DateTimeOffset newStart)
    {
        return new DateTimeRange(newStart, EndDateTime);
    }

    /// <summary>
    ///     Создать новый диапазон со сдвинутым окончанием.
    /// </summary>
    /// <param name="newEnd">Новая дата окончания.</param>
    public DateTimeRange WithEnd(DateTimeOffset newEnd)
    {
        return new DateTimeRange(StartDateTime, newEnd);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return StartDateTime;
        yield return EndDateTime;
    }
}