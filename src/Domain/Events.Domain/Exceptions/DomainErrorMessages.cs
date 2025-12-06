namespace Events.Domain.Exceptions;

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
    /// Ошибки тэга.
    /// </summary>
    public static class Tag
    {
        /// <summary>
        /// Тэг меньше минимальной длинны.
        /// </summary>
        public const string TagLessThanMinLength = "Тэг меньше минимальной длинны.";

        /// <summary>
        /// Тэг больше максимальной длинны.
        /// </summary>
        public const string TagGreaterThanMaxLength = "Тэг больше максимальной длинны.";

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