namespace Events.Domain.Exceptions;

/// <summary>
/// Исключения домена.
/// </summary>
public class DomainException : Exception
{
    public DomainException()
    {
    }

    public DomainException(string message)
        : base(message)
    {
    }
}