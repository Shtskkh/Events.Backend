namespace Events.Application.Services.Exceptions;

/// <inheritdoc />
public class UnauthorizedException : Exception
{
    /// <inheritdoc />
    public UnauthorizedException()
    {
    }

    /// <inheritdoc />
    public UnauthorizedException(string message)
        : base(message)
    {
    }
}