namespace Events.Domain.Shared;

/// <summary>
/// Сообщения об ошибках.
/// </summary>
public static class DomainErrorMessages
{
    /// <summary>
    /// Ошибки названия.
    /// </summary>
    public static class Title
    {
        /// <summary>
        /// Если название пустое,
        /// состоит из пробелов или null.
        /// </summary>
        public const string TitleNullOrWhiteSpace = "Название не может быть null или пустым";
    }

    /// <summary>
    /// Ошибки названия мероприятия.
    /// </summary>
    public static class EventTitle
    {
        /// <summary>
        /// Название мероприятия меньше минимальной длины. 
        /// </summary>
        public const string EventTitleLessThanMinLength = "Название мероприятия меньше минимальной длины.";

        /// <summary>
        /// Название мероприятия больше максимальной длины.
        /// </summary>
        public const string EventTitleGreaterThanMaxLength = "Название мероприятия больше максимальной длины.";
    }

    /// <summary>
    /// Ошибки анонса мероприятия.
    /// </summary>
    public static class EventAnnouncement
    {
        /// <summary>
        /// Анонс мероприятия null или пусто.
        /// </summary>
        public const string EventAnnouncementNullOrWhiteSpace = "Анонс мероприятия null или пусто.";

        /// <summary>
        /// Анонс мероприятия меньше минимальной длины.
        /// </summary>
        public const string EventAnnouncementLessThanMinLength = "Анонс мероприятия меньше минимальной длины.";

        /// <summary>
        /// Анонс мероприятия больше максимальной длины.
        /// </summary>
        public const string EventAnnouncementGreaterThanMaxLength = "Анонс мероприятия больше максимальной длины.";
    }

    /// <summary>
    /// Ошибки тэга.
    /// </summary>
    public static class Tag
    {
        /// <summary>
        /// Тэг меньше минимальной длинны.
        /// </summary>
        public const string TagLessThanMinLength = "Тэг меньше минимальной длины.";

        /// <summary>
        /// Тэг больше максимальной длинны.
        /// </summary>
        public const string TagGreaterThanMaxLength = "Тэг больше максимальной длины.";

        /// <summary>
        /// Тэг не должен содержать пробелов.
        /// </summary>
        public const string TagContainsWhiteSpace = "Тэг не должен содержать пробелов.";

        /// <summary>
        /// Тэг уже добавлен.
        /// </summary>
        public const string TagAlreadyAdded = "Тэг уже добавлен.";

        /// <summary>
        /// Тэг не найден.
        /// </summary>
        public const string TagNotFound = "Тэг не найден.";
    }

    /// <summary>
    /// Ошибки поста.
    /// </summary>
    public static class Post
    {
        /// <summary>
        /// Пост уже существует.
        /// </summary>
        public const string PostAlreadyExistForService = "Пост в данном внешнем сервисе для" +
                                                         "данного мероприятия уже существует.";

        /// <summary>
        /// Пост не найден.
        /// </summary>
        public const string PostNotFoundInService = "Пост не найден.";
    }
}