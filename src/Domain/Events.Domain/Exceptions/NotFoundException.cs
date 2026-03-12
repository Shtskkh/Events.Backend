namespace Events.Domain.Exceptions;

/// <summary>
///     Ошибка не найденной сущности репозитория.
/// </summary>
public class NotFoundException : Exception
{
    /// <inheritdoc />
    public NotFoundException()
    {
    }

    /// <inheritdoc />
    public NotFoundException(string message) : base(message)
    {
    }
}