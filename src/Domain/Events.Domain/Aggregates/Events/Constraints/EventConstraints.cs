namespace Events.Domain.Aggregates.Events.Constraints;

/// <summary>
///     Константы мероприятия.
/// </summary>
public static class EventConstraints
{
    /// <summary>
    ///     Константы названия.
    /// </summary>
    public static class Title
    {
        public const int MaxLength = 128;
    }

    /// <summary>
    ///     Константы анонса.
    /// </summary>
    public static class Announcement
    {
        public const int MaxLength = 64;
    }

    /// <summary>
    ///     Константы описания.
    /// </summary>
    public static class Description
    {
        public const int MaxLength = 512;
    }

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