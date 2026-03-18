namespace Events.Contracts.Features.Users.DTOs;

/// <summary>
///     Модель аутентификации пользователя.
/// </summary>
public record AuthDto
{
    /// <summary>
    ///     Почтовый адрес.
    /// </summary>
    public required string Email { get; init; }

    /// <summary>
    ///     Пароль.
    /// </summary>
    public required string Password { get; init; }
}