using Events.Domain.Shared;

namespace Events.Application.Services.Exceptions;

public class UnauthorizedException(Error error) : Exception(error.ErrorMessage)
{
    public Error Error { get; } = error;
}