using Events.Domain.Aggregates.Users;

namespace Events.Application.Services.Features.Tokens.Jwt;

/// <summary>
///     Сервис JWT токенов.
/// </summary>
public interface IJwtTokenService
{
    /// <summary>
    ///     Сгенерировать access token.
    /// </summary>
    /// <param name="user">Пользователь.</param>
    /// <returns>Строка access token.</returns>
    public string GenerateAccessToken(User user);
}