using MediatR;

namespace Events.Application.Services.Features.Users.Commands.Delete;

public sealed record DeleteUserCommand(Guid Id) : IRequest;