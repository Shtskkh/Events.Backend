using Events.Contracts.Users;
using MediatR;

namespace Events.Application.Services.Features.Users.Commands.Auth;

/// <inheritdoc />
public sealed record AuthUserCommand(AuthDto Dto) : IRequest<TokenDto>;