namespace Events.Infrastructure.DataAccess.Exceptions;

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