using Events.Application.Services.Exceptions;
using Events.Application.Services.Features.Tokens.Jwt;
using Events.Application.Services.Features.Users.Repositories;
using Events.Application.Services.Shared;
using Events.Contracts.Users;
using Events.Domain.Aggregates.UserAggregate;
using Events.Domain.Exceptions;
using MediatR;

namespace Events.Application.Services.Features.Users.Commands.Auth;

/// <inheritdoc />
public class AuthUserHandler(IUserRepository userRepository, IJwtTokenService tokenService)
    : IRequestHandler<AuthUserCommand, TokenDto>
{
    /// <inheritdoc />
    public async Task<TokenDto> Handle(AuthUserCommand request, CancellationToken cancellationToken)
    {
        var authDto = request.Dto;

        User user;
        try
        {
            user = await userRepository.GetByEmail(authDto.Email, cancellationToken);
        }
        catch (NotFoundException)
        {
            throw new UnauthorizedException(ApplicationErrorMessages.User.Unauthorized);
        }

        if (user.Password.Value != authDto.Password)
            throw new UnauthorizedException(ApplicationErrorMessages.User.Unauthorized);

        var accessToken = tokenService.GenerateAccessToken(user);
        return new TokenDto(accessToken);
    }
}