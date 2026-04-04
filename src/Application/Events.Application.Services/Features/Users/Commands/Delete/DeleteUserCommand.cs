using MediatR;

namespace Events.Application.Services.Features.Users.Commands.Delete;

/// <inheritdoc />
public record DeleteUserCommand(Guid Id) : IRequest;