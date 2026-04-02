namespace Events.Contracts.Features.Users;

/// <summary>
///     Модель изменения пароля.
/// </summary>
public record ChangePasswordDto
{
    /// <summary>
    ///     Старый пароль.
    /// </summary>
    public required string OldPassword { get; init; } = null!;

    /// <summary>
    ///     Новый пароль.
    /// </summary>
    public required string NewPassword { get; init; } = null!;
}