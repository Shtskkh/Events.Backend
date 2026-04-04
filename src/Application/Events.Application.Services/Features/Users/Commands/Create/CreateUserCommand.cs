using Events.Contracts.Users;
using MediatR;

namespace Events.Application.Services.Features.Users.Commands.Create;

/// <summary>
///     Команда создания пользователя.
/// </summary>
/// <param name="Dto"></param>
public sealed record CreateUserCommand(CreateUserDto Dto) : IRequest<Guid>;