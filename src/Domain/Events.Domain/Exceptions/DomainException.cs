using Events.Domain.Shared;

namespace Events.Domain.Exceptions;

/// <summary>
///     Ошибка правил домена.
/// </summary>
public class DomainException(Error error) : Exception(error.ErrorMessage)
{
    public Error Error { get; } = error;
}