namespace Events.Domain.Shared;

/// <summary>
/// Константы.
/// </summary>
public static class DomainConstraints
{
    /// <summary>
    /// Константы мероприятия.
    /// </summary>
    public static class Event
    {
        /// <summary>
        /// Минимальное число участников мероприятия.
        /// </summary>
        public const int MinParticipantsCount = 2;
    }

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
    /// Константы анонса мероприятия.
    /// </summary>
    public static class EventAnnouncement
    {
        /// <summary>
        /// Минимальная длина анонса мероприятия.
        /// </summary>
        public const int MinLength = 2;

        /// <summary>
        /// Максимальная длина анонса мероприятия.
        /// </summary>
        public const int MaxLength = 64;
    }

    /// <summary>
    /// Константы описания мероприятия.
    /// </summary>
    public static class EventDescription
    {
        /// <summary>
        /// Минимальная длина описания мероприятия.
        /// </summary>
        public const int MinLength = 2;

        /// <summary>
        /// Максимальная длина описания мероприятия.
        /// </summary>
        public const int MaxLength = 512;
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