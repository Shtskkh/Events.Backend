using Events.Domain.Shared;

namespace Events.Domain.Exceptions;

/// <summary>
///     Ошибка отсутствия запрашиваемого ресурса.
/// </summary>
public class NotFoundException : Exception
{
    public NotFoundException()
    {
    }

    public NotFoundException(string message) : base(message)
    {
    }

    public NotFoundException(Error error) : base(error.ErrorMessage)
    {
        Error = error;
    }

    public Error Error { get; }
}