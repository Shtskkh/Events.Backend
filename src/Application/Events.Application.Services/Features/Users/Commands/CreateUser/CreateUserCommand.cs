using Events.Contracts.Features.Users.DTOs;
using MediatR;

namespace Events.Application.Services.Features.Users.Commands.CreateUser;

/// <summary>
///     Команда создания пользователя.
/// </summary>
/// <param name="Dto"></param>
public record CreateUserCommand(CreateUserDto Dto) : IRequest<Guid>;