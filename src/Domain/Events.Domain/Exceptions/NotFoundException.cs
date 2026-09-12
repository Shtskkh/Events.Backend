using Events.Domain.Shared;

namespace Events.Domain.Exceptions;

/// <summary>
///     Ошибка отсутствия запрашиваемого ресурса.
/// </summary>
public class NotFoundException(Error error) : Exception(error.ErrorMessage)
{
    public Error Error { get; } = error;
}