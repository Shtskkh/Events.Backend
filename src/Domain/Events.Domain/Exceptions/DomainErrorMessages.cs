namespace Events.Domain.Exceptions;

/// <summary>
/// Сообщения об ошибках.
/// </summary>
public static class DomainErrorMessages
{
    /// <summary>
    /// Если название пустое,
    /// состоит из пробелов или null.
    /// </summary>
    public const string TitleNullOrWhiteSpace = "Название не может быть null или пустым";

    /// <summary>
    /// Название тэга мероприятия
    /// не должно содержать пробелов.
    /// </summary>
    public const string TagContainsWhiteSpace = "Название тэга не должно содержать пробелов.";

    /// <summary>
    /// Тэг уже добавлен.
    /// </summary>
    public const string TagAlreadyAdded = "Тэг уже добавлен к мероприятию.";

    /// <summary>
    /// Тэг не найден.
    /// </summary>
    public const string TagNotFound = "Тэг не найден у мероприятия.";

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