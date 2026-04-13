namespace Events.Domain.Aggregates.Locations.Constraints;

/// <summary>
///     Константы помещений.
/// </summary>
public static class PlaceConstraints
{
    /// <summary>
    ///     Константы названия.
    /// </summary>
    public static class Title
    {
        public const int MaxLength = 64;
    }

    /// <summary>
    ///     Константы номеров.
    /// </summary>
    public static class Number
    {
        public const int MaxLength = 4;
    }

    /// <summary>
    ///     Константы типа.
    /// </summary>
    public static class Type
    {
        public const int MaxLength = 16;
    }
}