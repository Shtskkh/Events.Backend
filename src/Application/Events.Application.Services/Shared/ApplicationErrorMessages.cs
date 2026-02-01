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

            public static readonly string SizeGreaterThanMax =
                $"Размер выборки должен быть меньше чем {ApplicationConstraints.Event.Filter.MaxSize}.";
        }
    }
}