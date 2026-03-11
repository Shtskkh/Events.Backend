using MediatR;

namespace Events.Application.Services.Features.Users.Commands.DeleteUser;

/// <inheritdoc />
public record DeleteUserCommand(Guid Id) : IRequest;