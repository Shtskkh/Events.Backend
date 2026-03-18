namespace Events.Contracts.Features.Users.DTOs;

/// <summary>
///     Модель Jwt токенов.
/// </summary>
/// <param name="AccessToken">Токен доступа.</param>
/// <param name="RefreshToken">Токен замены.</param>
public record TokenDto(string AccessToken, string RefreshToken = "");