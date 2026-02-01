namespace Events.Application.Services.Shared;

/// <summary>
///     Константные значения для application.
/// </summary>
public static class ApplicationConstraints
{
    /// <summary>
    ///     Константы мероприятия.
    /// </summary>
    public static class Event
    {
        /// <summary>
        ///     Константы фильтра мероприятий.
        /// </summary>
        public static class Filter
        {
            /// <summary>
            ///     Максимальный размер выборки.
            /// </summary>
            public const int MaxSize = 30;
        }
    }
}