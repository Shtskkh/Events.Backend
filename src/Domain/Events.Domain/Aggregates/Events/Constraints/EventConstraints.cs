namespace Events.Domain.Aggregates.Events.Constraints;

/// <summary>
///     Константы мероприятия.
/// </summary>
public static class EventConstraints
{
    /// <summary>
    ///     Константы временного промежутка.
    /// </summary>
    public static class DateTimeRange
    {
        public const int MaxDurationInDays = 31;
    }

    /// <summary>
    ///     Константы типа.
    /// </summary>
    public static class Type
    {
        public const int MaxLength = 16;
    }
}