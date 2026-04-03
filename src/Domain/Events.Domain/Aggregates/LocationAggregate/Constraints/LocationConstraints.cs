namespace Events.Domain.Aggregates.LocationAggregate.Constraints;

/// <summary>
///     Константы локаций.
/// </summary>
public static class LocationConstraints
{
    /// <summary>
    ///     Константы названия.
    /// </summary>
    public static class Title
    {
        public const int MaxLength = 256;
    }

    /// <summary>
    ///     Константы адреса.
    /// </summary>
    public static class Address
    {
        public const int MaxLength = 256;
    }
}