namespace Events.Domain.Shared;

/// <summary>
///     Сообщения об ошибках домена.
/// </summary>
public static class DomainErrorMessages
{
    /// <summary>
    ///     Ошибки текста.
    /// </summary>
    public static class Text
    {
        /// <summary>
        ///     Строка текста пустая или состоит из пробелов.
        /// </summary>
        public const string NullOrWhiteSpace = "Текстовое поле не может быть null или пустым.";
    }

    /// <summary>
    ///     Ошибки мероприятия.
    /// </summary>
    public static class Event
    {
        /// <summary>
        ///     Ошибки названия мероприятия.
        /// </summary>
        public static class Title
        {
            /// <summary>
            ///     Длина названия мероприятия меньше минимальной длины.
            /// </summary>
            public const string LessThanMinLenght = "Название мероприятия меньше минимальной длины.";

            /// <summary>
            ///     Длина названия мероприятия больше максимальной длины.
            /// </summary>
            public const string GreaterThanMaxLength = "Название мероприятия больше максимальной длины.";
        }

        /// <summary>
        ///     Ошибки анонса мероприятия.
        /// </summary>
        public static class Announcement
        {
            /// <summary>
            ///     Длина анонса мероприятия меньше минимальной длины.
            /// </summary>
            public const string LessThanMinLenght = "Анонс мероприятия меньше минимальной длины.";

            /// <summary>
            ///     Длина анонса мероприятия больше максимальной длины.
            /// </summary>
            public const string GreaterThanMaxLength = "Анонс мероприятия больше максимальной длины.";
        }

        /// <summary>
        ///     Ошибки описания мероприятия.
        /// </summary>
        public static class Description
        {
            /// <summary>
            ///     Длина описания мероприятия меньше минимальной длины.
            /// </summary>
            public const string LessThanMinLenght = "Описание мероприятия меньше минимальной длины.";

            /// <summary>
            ///     Длина описания мероприятия больше максимальной длины.
            /// </summary>
            public const string GreaterThanMaxLength = "Описание мероприятия больше максимальной длины.";
        }
    }
}