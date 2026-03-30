namespace Events.Infrastructure.DataAccess.Shared;

/// <summary>
///     Ошибки data access.
/// </summary>
public static class DataAccessErrorMessages
{
    /// <summary>
    ///     Ошибки мероприятия.
    /// </summary>
    public static class Event
    {
        public const string NotFound = "Мероприятие не найдено.";

        public const string NotFoundAny = "Мероприятия не найдены.";

        /// <summary>
        ///     Ошибки типа мероприятия.
        /// </summary>
        public static class Type
        {
            public const string NotFound = "Тип мероприятия не найден.";
        }

        /// <summary>
        ///     Ошибки формата мероприятия.
        /// </summary>
        public static class Format
        {
            public const string NotFound = "Формат мероприятия не найден.";
        }
    }

    /// <summary>
    ///     Ошибки локаций.
    /// </summary>
    public static class Location
    {
        public const string NotFoundAny = "Локации не найдены.";
        public const string NotFound = "Локация не найдена.";
    }

    /// <summary>
    ///     Ошибки помещений.
    /// </summary>
    public static class Places
    {
        public const string NotFoundAny = "Помещения не найдены.";

        /// <summary>
        ///     Помещение не найдено.
        /// </summary>
        public const string NotFound = "Помещение не найдено.";

        /// <summary>
        ///     Ошибки типов помещений.
        /// </summary>
        public static class Types
        {
            public const string NotFoundAny = "Типы помещений не найдены.";
            public const string NotFound = "Тип помещения не найден.";
        }
    }

    /// <summary>
    ///     Ошибки файлов.
    /// </summary>
    public static class Files
    {
        public const string NotFound = "Файл не найден.";

        public const string NotFoundAny = "Файлы не найдены.";
    }

    /// <summary>
    ///     Ошибки пользователей.
    /// </summary>
    public static class Users
    {
        public const string NotFoundAny = "Пользователи не найдены.";

        public const string NotFound = "Пользователь не найден.";

        /// <summary>
        ///     Ошибки роли пользователя.
        /// </summary>
        public static class Roles
        {
            public const string NotFound = "Роль не найдена.";
        }
    }

    /// <summary>
    ///     Ошибки оборудования.
    /// </summary>
    public static class Equipment
    {
        /// <summary>
        ///     Ошибки типов оборудования.
        /// </summary>
        public static class Types
        {
            public const string NotFoundAny = "Типы оборудования не найдены.";
            public const string NotFound = "Тип оборудования не найден.";
        }
    }
}