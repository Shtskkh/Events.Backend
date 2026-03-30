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

    /// <summary>
    ///     Константы помещений.
    /// </summary>
    public static class Place
    {
        /// <summary>
        ///     Константы названия помещения.
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
            public const int MaxLength = 64;
        }

        /// <summary>
        ///     Константы номеров помещений.
        /// </summary>
        public static class Number
        {
            /// <summary>
            ///     Минимальная длина.
            /// </summary>
            public const int MinLength = 1;

            /// <summary>
            ///     Максимальная длина.
            /// </summary>
            public const int MaxLength = 4;
        }

        /// <summary>
        ///     Константы типа помещения.
        /// </summary>
        public static class Type
        {
            /// <summary>
            ///     Минимальная длина названия типа помещения.
            /// </summary>
            public const int MinLength = 1;

            /// <summary>
            ///     Максимальная длина названия типа помещения.
            /// </summary>
            public const int MaxLength = 16;
        }
    }

    /// <summary>
    ///     Константы пользователей.
    /// </summary>
    public static class User
    {
        /// <summary>
        ///     Константы ролей пользователей.
        /// </summary>
        public static class Role
        {
            /// <summary>
            ///     Максимальная длина названия роли.
            /// </summary>
            public const int MaxLength = 16;
        }

        /// <summary>
        ///     Константы ФИО пользователя.
        /// </summary>
        public static class PersonName
        {
            /// <summary>
            ///     Максимальная длина поля.
            /// </summary>
            public const int MaxLength = 64;
        }
    }

    /// <summary>
    ///     Константы почтового адреса.
    /// </summary>
    public static class Email
    {
        /// <summary>
        ///     Максимальная длина почтового адреса.
        /// </summary>
        public const int MaxLength = 512;
    }

    /// <summary>
    ///     Константы паролей.
    /// </summary>
    public static class Password
    {
        /// <summary>
        ///     Минимальная длина пароля.
        /// </summary>
        public const int MinLength = 6;

        /// <summary>
        ///     Максимальная длина пароля.
        /// </summary>
        public const int MaxLength = 512;

        /// <summary>
        ///     Недопустимые символы в пароле.
        /// </summary>
        public static readonly char[] InvalidCharacters = [' ', '\t', '\n'];
    }

    /// <summary>
    ///     Константы оборудования.
    /// </summary>
    public static class Equipment
    {
        /// <summary>
        ///     Максимальная длина названия.
        /// </summary>
        public const int MaxLength = 64;

        /// <summary>
        ///     Константы типов оборудования.
        /// </summary>
        public static class Type
        {
            /// <summary>
            ///     Максимальная длина названия.
            /// </summary>
            public const int MaxLength = 32;
        }
    }
}