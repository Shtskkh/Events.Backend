namespace Events.Domain.Shared;

/// <summary>
///     Константы домена.
/// </summary>
public static class DomainConstraints
{
    /// <summary>
    ///     Константы мероприятия.
    /// </summary>
    public static class Event
    {
        /// <summary>
        ///     Константы названия мероприятия.
        /// </summary>
        public static class Title
        {
            /// <summary>
            ///     Минимальная длина названия мероприятия.
            /// </summary>
            public const int MinLength = 5;

            /// <summary>
            ///     Максимальная длина названия мероприятия.
            /// </summary>
            public const int MaxLength = 128;
        }

        /// <summary>
        ///     Константы анонса мероприятия.
        /// </summary>
        public static class Announcement
        {
            /// <summary>
            ///     Минимальная длина анонса мероприятия.
            /// </summary>
            public const int MinLength = 5;

            /// <summary>
            ///     Максимальная длина анонса мероприятия.
            /// </summary>
            public const int MaxLength = 64;
        }

        /// <summary>
        ///     Константы описания мероприятия.
        /// </summary>
        public static class Description
        {
            /// <summary>
            ///     Минимальная длина описания мероприятия.
            /// </summary>
            public const int MinLength = 5;

            /// <summary>
            ///     Максимальная длина описания мероприятия.
            /// </summary>
            public const int MaxLength = 512;
        }
    }
}