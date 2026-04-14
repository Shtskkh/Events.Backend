using Events.Application.Services.Exceptions;
using Events.Application.Services.Features.Tokens.Jwt;
using Events.Application.Services.Features.Users.Specifications;
using Events.Application.Services.Shared;
using Events.Contracts.Users;
using Events.Domain.Aggregates.Users;
using Events.Domain.Aggregates.Users.Errors;
using MediatR;

namespace Events.Application.Services.Features.Users.Commands.Auth;

public sealed class AuthUserHandler(IRepository<User> userRepository, IJwtTokenService tokenService)
    : IRequestHandler<AuthUserCommand, TokenDto>
{
    public async Task<TokenDto> Handle(AuthUserCommand request, CancellationToken cancellationToken)
    {
        var authDto = request.Dto;

        var userSpec = new UserByEmailSpec(authDto.Email);
        var user = await userRepository.FirstOrDefaultAsync(userSpec, cancellationToken);

        if (user == null || user.Password.Value != authDto.Password)
            throw new UnauthorizedException(UserErrorMessages.Unauthorized);

        var accessToken = tokenService.GenerateAccessToken(user);

        return new TokenDto(accessToken);
    }
}