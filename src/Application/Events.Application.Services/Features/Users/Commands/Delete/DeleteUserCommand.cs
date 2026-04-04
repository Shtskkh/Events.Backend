using MediatR;

namespace Events.Application.Services.Features.Users.Commands.Delete;

/// <inheritdoc />
public sealed record DeleteUserCommand(Guid Id) : IRequest;