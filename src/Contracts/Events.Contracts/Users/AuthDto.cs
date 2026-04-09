namespace Events.Contracts.Users;

/// <summary>
///     Модель аутентификации пользователя.
/// </summary>
public sealed record AuthDto
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