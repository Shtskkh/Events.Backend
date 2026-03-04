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
        /// <summary>
        ///     Мероприятие не найдено.
        /// </summary>
        public const string NotFound = "Мероприятие не найдено.";

        /// <summary>
        ///     Ошибки типа мероприятия.
        /// </summary>
        public static class Type
        {
            /// <summary>
            ///     Тип мероприятия не найден.
            /// </summary>
            public const string NotFound = "Тип мероприятия не найден.";
        }

        /// <summary>
        ///     Ошибки формата мероприятия.
        /// </summary>
        public static class Format
        {
            /// <summary>
            ///     Формат мероприятия не найден.
            /// </summary>
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
        /// <summary>
        ///     Файл не найден.
        /// </summary>
        public const string NotFound = "Файл не найден.";
    }
}