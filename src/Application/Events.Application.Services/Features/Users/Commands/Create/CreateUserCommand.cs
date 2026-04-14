using Events.Contracts.Users;
using MediatR;

namespace Events.Application.Services.Features.Users.Commands.Create;

public sealed record CreateUserCommand(CreateUserDto Dto) : IRequest<Guid>;