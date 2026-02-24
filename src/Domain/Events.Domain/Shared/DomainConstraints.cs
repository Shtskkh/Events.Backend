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
            public const int MinLength = 2;

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
            public const int MinLength = 2;

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
            public const int MinLength = 2;

            /// <summary>
            ///     Максимальная длина описания мероприятия.
            /// </summary>
            public const int MaxLength = 512;
        }

        /// <summary>
        ///     Константы временного промежутка мероприятия.
        /// </summary>
        public static class DateTimeRange
        {
            /// <summary>
            ///     Максимальная длина мероприятия в днях.
            /// </summary>
            public const int MaxDurationInDays = 31;
        }

        /// <summary>
        ///     Константы типа мероприятия.
        /// </summary>
        public static class Type
        {
            /// <summary>
            ///     Минимальная длина названия типа мероприятия.
            /// </summary>
            public const int MinLength = 2;

            /// <summary>
            ///     Максимальная длина названия типа мероприятия.
            /// </summary>
            public const int MaxLength = 16;
        }
    }

    /// <summary>
    ///     Константы локаций.
    /// </summary>
    public static class Location
    {
        /// <summary>
        ///     Константы названия локации.
        /// </summary>
        public static class Title
        {
            /// <summary>
            ///     Минимальная длина.
            /// </summary>
            public const int MinLength = 1;

            /// <summary>
            ///     Максимальная длина.
            /// </summary>
            public const int MaxLength = 256;
        }

        /// <summary>
        ///     Константы адреса локации.
        /// </summary>
        public static class Address
        {
            /// <summary>
            ///     Минимальная длина.
            /// </summary>
            public const int MinLength = 1;

            /// <summary>
            ///     Максимальная длина.
            /// </summary>
            public const int MaxLength = 256;
        }
    }
}