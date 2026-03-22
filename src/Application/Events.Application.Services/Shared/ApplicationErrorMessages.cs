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
            public const string PageLessOrEqualToZero = "Страница выборки должна быть больше 0.";

            public const string SizeLessOrEqualToZero = "Размер выборки должен быть больше 0.";

            public const string TypeIdLessOrEqualToZero = "ID типа мероприятия должен быть больше 0.";

            public const string FormatIdLessOrEqualToZero = "ID формата мероприятия должен быть больше 0.";

            public static readonly string SizeGreaterThanMax =
                $"Размер выборки должен быть меньше чем {ApplicationConstraints.Event.Filter.MaxSize}.";
        }

        /// <summary>
        ///     Ошибки создания мероприятия.
        /// </summary>
        public static class Creation
        {
            public const string PreviewFileSizeExceedsLimit = "Размер файла превью не должен превышать 5 МБ.";
            
            public const string PreviewFileContentTypeNotAllowed = "Тип файла превью не разрешён.";
        }
    }

    /// <summary>
    ///     Ошибки пользователей.
    /// </summary>
    public static class User
    {
        public const string Unauthorized = "Неверный почтовый адрес или пароль";
    }
}