using Events.Domain.Shared;

namespace Events.Domain.Exceptions;

/// <summary>
///     Ошибка правил домена.
/// </summary>
public class DomainException : Exception
{
    public DomainException()
    {
    }

    public DomainException(string message) : base(message)
    {
    }

    public DomainException(Error error) : base(error.ErrorMessage)
    {
        Error = error;
    }

    public Error Error { get; }
}