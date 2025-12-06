namespace Events.Domain.Shared;

/// <summary>
/// Константы.
/// </summary>
public static class DomainConstraints
{
    /// <summary>
    /// Константы названия мероприятия.
    /// </summary>
    public static class EventTitle
    {
        /// <summary>
        /// Минимальная длина названия мероприятия.
        /// </summary>
        public const int MinLength = 2;

        /// <summary>
        /// Максимальная длина названия мероприятия.
        /// </summary>
        public const int MaxLength = 128;
    }

    /// <summary>
    /// Константы тэга.
    /// </summary>
    public static class Tag
    {
        /// <summary>
        /// Минимальная длина тэга.
        /// </summary>
        public const int MinLength = 2;

        /// <summary>
        /// Максимальная длина тэга.
        /// </summary>
        public const int MaxLength = 32;
    }
}