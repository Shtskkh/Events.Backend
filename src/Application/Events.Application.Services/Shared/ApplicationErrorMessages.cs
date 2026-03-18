namespace Events.Application.Services.Shared;

/// <summary>
///     Сообщения для ошибок application.
/// </summary>
public static class ApplicationErrorMessages
{
    /// <summary>
    ///     Ошибки мероприятий.
    /// </summary>
    public static class Event
    {
        /// <summary>
        ///     Ошибки фильтра мероприятий.
        /// </summary>
        public static class Filter
        {
            /// <summary>
            ///     Страница выборки меньше или равна нулю.
            /// </summary>
            public const string PageLessOrEqualToZero = "Страница выборки должна быть больше 0.";

            /// <summary>
            ///     Размер выборки меньше или равен нулю.
            /// </summary>
            public const string SizeLessOrEqualToZero = "Размер выборки должен быть больше 0.";

            /// <summary>
            ///     Id типа мероприятия меньше или равен нулю.
            /// </summary>
            public const string TypeIdLessOrEqualToZero = "ID типа мероприятия должен быть больше 0.";

            /// <summary>
            ///     Id формата мероприятия меньше или равен нулю.
            /// </summary>
            public const string FormatIdLessOrEqualToZero = "ID формата мероприятия должен быть больше 0.";

            /// <summary>
            ///     Размер выборки больше максимального.
            /// </summary>
            public static readonly string SizeGreaterThanMax =
                $"Размер выборки должен быть меньше чем {ApplicationConstraints.Event.Filter.MaxSize}.";
        }

        /// <summary>
        ///     Ошибки создания мероприятия.
        /// </summary>
        public static class Creation
        {
            /// <summary>
            ///     Файл превью превышает допустимый размер.
            /// </summary>
            public const string PreviewFileSizeExceedsLimit = "Размер файла превью не должен превышать 5 МБ.";

            /// <summary>
            ///     Тип файла превью не разрешён.
            /// </summary>
            public const string PreviewFileContentTypeNotAllowed = "Тип файла превью не разрешён.";
        }
    }

    /// <summary>
    ///     Ошибки пользователей.
    /// </summary>
    public static class User
    {
        /// <summary>
        ///     Не авторизирован.
        /// </summary>
        public const string Unauthorized = "Неверный почтовый адрес или пароль";
    }
}