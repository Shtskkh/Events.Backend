using System.Net.Mime;

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

        /// <summary>
        ///     Константы создания мероприятия.
        /// </summary>
        public static class Creation
        {
            /// <summary>
            ///     Максимальный размер превью (5 МБ).
            /// </summary>
            public const int MaxSize = 5 * 1024 * 1024;

            /// <summary>
            ///     Разрешённые типы файлов превью.
            /// </summary>
            public static readonly string[] AllowedMimeTypes =
                [MediaTypeNames.Image.Jpeg, MediaTypeNames.Image.Png, MediaTypeNames.Image.Webp];
        }
    }
}