namespace Events.Domain.Exceptions;

/// <summary>
/// Исключения домена.
/// </summary>
public class DomainException : Exception
{
    /// <summary>
    /// Конструктор.
    /// </summary>
    public DomainException()
    {
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="message">Сообщение ошибки.</param>
    public DomainException(string message)
        : base(message)
    {
    }
}