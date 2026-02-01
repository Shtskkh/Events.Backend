namespace Events.Domain.Exceptions;

/// <summary>
///     Ошибка правил домена.
/// </summary>
public class DomainException : Exception
{
    /// <inheritdoc />
    public DomainException()
    {
    }

    /// <inheritdoc />
    public DomainException(string message) : base(message)
    {
    }
}