namespace Events.Domain.Shared;

/// <summary>
/// Сообщения об ошибках.
/// </summary>
public static class DomainErrorMessages
{
    /// <summary>
    /// Ошибки названия.
    /// </summary>
    public static class TitleErrors
    {
        public const string TitleNullOrWhiteSpace = "Название не может быть null или пустым";
    }

    /// <summary>
    /// Ошибки мероприятия.
    /// </summary>
    public static class EventErrors
    {
        public const string MaxParticipantsCountLessThanMin =
            "Максимальное количество участников меньше минимально возможного.";
    }

    /// <summary>
    /// Ошибки названия мероприятия.
    /// </summary>
    public static class EventTitleErrors
    {
        public const string EventTitleLessThanMinLength = "Название мероприятия меньше минимальной длины.";

        public const string EventTitleGreaterThanMaxLength = "Название мероприятия больше максимальной длины.";
    }

    /// <summary>
    /// Ошибки анонса мероприятия.
    /// </summary>
    public static class EventAnnouncementErrors
    {
        public const string EventAnnouncementNullOrWhiteSpace = "Анонс мероприятия null или пусто.";

        public const string EventAnnouncementLessThanMinLength = "Анонс мероприятия меньше минимальной длины.";

        public const string EventAnnouncementGreaterThanMaxLength = "Анонс мероприятия больше максимальной длины.";
    }

    public static class EventDescriptionErrors
    {
        public const string EventDescriptionNullOrWhiteSpace = "Описание мероприятия null или пусто.";

        public const string EventDescriptionLessThanMinLength = "Описание мероприятия меньше минимальной длины.";

        public const string EventDescriptionGreaterThanMaxLength = "Описание мероприятия больше максимальной длины.";
    }

    /// <summary>
    /// Ошибки тэга.
    /// </summary>
    public static class TagErrors
    {
        public const string TagLessThanMinLength = "Тэг меньше минимальной длины.";

        public const string TagGreaterThanMaxLength = "Тэг больше максимальной длины.";

        public const string TagContainsWhiteSpace = "Тэг не должен содержать пробелов.";

        public const string TagAlreadyAdded = "Тэг уже добавлен.";

        public const string TagNotFound = "Тэг не найден.";
    }

    /// <summary>
    /// Ошибки поста.
    /// </summary>
    public static class PostErrors
    {
        public const string PostNotFound = "Пост не найден.";
    }
}