namespace Events.Domain.Exceptions;

/// <summary>
/// Сообщения об ошибках.
/// </summary>
public static class DomainErrorMessages
{
    public static class Title
    {
        /// <summary>
        /// Если название пустое,
        /// состоит из пробелов или null.
        /// </summary>
        public const string TitleNullOrWhiteSpace = "Название не может быть null или пустым";
    }

    public static class Tag
    {
        /// <summary>
        /// Название тэга не должно содержать пробелов.
        /// </summary>
        public const string TagContainsWhiteSpace = "Название тэга не должно содержать пробелов.";

        /// <summary>
        /// Тэг уже добавлен.
        /// </summary>
        public const string TagAlreadyAdded = "Тэг уже добавлен.";

        /// <summary>
        /// Тэг не найден.
        /// </summary>
        public const string TagNotFound = "Тэг не найден.";
    }

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