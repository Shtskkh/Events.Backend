using Events.Domain.Aggregates.EventAggregate.Constraints;
using Events.Domain.Aggregates.EventAggregate.Errors;
using Events.Domain.Exceptions;
using Events.Domain.Shared;

namespace Events.Domain.Aggregates.EventAggregate.ValueObjects;

/// <summary>
///     Диапазона дат мероприятия.
/// </summary>
public class EventDateTimeRange : ValueObject
{
    private EventDateTimeRange()
    {
    }

    /// <summary>
    ///     Конструктор.
    /// </summary>
    /// <param name="start">Дата и время начала.</param>
    /// <param name="end">Дата и время окончания.</param>
    /// <exception cref="DomainException">Ошибка правил домена.</exception>
    public EventDateTimeRange(DateTimeOffset start, DateTimeOffset end)
    {
        if (start >= end)
            throw new DomainException(EventErrorMessages.DateTimeRange.StartLaterThanEnd);

        if (end - start > TimeSpan.FromDays(EventConstraints.DateTimeRange.MaxDurationInDays))
            throw new DomainException(EventErrorMessages.DateTimeRange.DurationGreaterThanMax);

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
    public EventDateTimeRange WithStart(DateTimeOffset newStart)
    {
        return new EventDateTimeRange(newStart, EndDateTime);
    }

    /// <summary>
    ///     Создать новый диапазон со сдвинутым окончанием.
    /// </summary>
    /// <param name="newEnd">Новая дата окончания.</param>
    public EventDateTimeRange WithEnd(DateTimeOffset newEnd)
    {
        return new EventDateTimeRange(StartDateTime, newEnd);
    }

    /// <inheritdoc />
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return StartDateTime;
        yield return EndDateTime;
    }
}