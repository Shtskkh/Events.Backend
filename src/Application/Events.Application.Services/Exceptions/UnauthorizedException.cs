using Events.Domain.Shared;

namespace Events.Application.Services.Exceptions;

public class UnauthorizedException : Exception
{
    public UnauthorizedException()
    {
    }

    public UnauthorizedException(string message)
        : base(message)
    {
    }

    public UnauthorizedException(Error error) : base(error.ErrorMessage)
    {
        Error = error;
    }

    public Error Error { get; }
}