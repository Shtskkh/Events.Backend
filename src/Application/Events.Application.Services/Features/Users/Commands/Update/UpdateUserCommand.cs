using Events.Contracts.Users;
using IRequest = MediatR.IRequest;

namespace Events.Application.Services.Features.Users.Commands.Update;

public sealed record UpdateUserCommand(Guid UserId, UpdateUserDto Dto) : IRequest;