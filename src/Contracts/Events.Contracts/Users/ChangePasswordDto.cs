using System.ComponentModel.DataAnnotations;
using Events.Domain.Shared.Constraints;

namespace Events.Contracts.Users;

/// <summary>
///     Модель изменения пароля.
/// </summary>
public sealed record ChangePasswordDto
{
    /// <summary>
    ///     Старый пароль.
    /// </summary>
    public required string OldPassword { get; init; } = null!;

    /// <summary>
    ///     Новый пароль.
    /// </summary>
    [MaxLength(PasswordConstraints.MaxLength)]
    public required string NewPassword { get; init; } = null!;
}