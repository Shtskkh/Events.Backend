using Events.Contracts.Users;
using MediatR;

namespace Events.Application.Services.Features.Users.Commands.AuthUser;

/// <inheritdoc />
public record AuthUserCommand(AuthDto Dto) : IRequest<TokenDto>;