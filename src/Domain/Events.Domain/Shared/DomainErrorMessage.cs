namespace Events.Domain.Shared;

/// <summary>
/// Сообщения об ошибках.
/// </summary>
public static class DomainErrorMessage
{
    /// <summary>
    /// Если название пустое,
    /// состоит из пробелов или null.
    /// </summary>
    public const string TitleNullOrWhiteSpaceException = "Название не может быть null или пустым";
    
    /// <summary>
    /// Название тэга мероприятия
    /// не должно содержать пробелов.
    /// </summary>
    public const string TagContainsWhiteSpace = "Название тэга не должно содержать пробелов.";
}