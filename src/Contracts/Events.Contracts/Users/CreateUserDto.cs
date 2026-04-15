using System.ComponentModel.DataAnnotations;
using Events.Domain.Aggregates.Users.ValueObjects;
using Events.Domain.Shared.Constraints;
using Microsoft.AspNetCore.Http;

namespace Events.Contracts.Users;

/// <summary>
///     Форма создания пользователя.
/// </summary>
public sealed record CreateUserDto
{
    /// <summary>
    ///     Имя.
    /// </summary>
    [MaxLength(PersonName.MaxLength)]
    public required string FirstName { get; set; }

    /// <summary>
    ///     Фамилия.
    /// </summary>
    [MaxLength(PersonName.MaxLength)]
    public required string LastName { get; set; }

    /// <summary>
    ///     Отчество.
    /// </summary>
    [MaxLength(PersonName.MaxLength)]
    public string? Patronymic { get; set; }

    /// <summary>
    ///     Почтовый адрес.
    /// </summary>
    [MaxLength(EmailConstraints.MaxLength)]
    public required string Email { get; set; }

    /// <summary>
    ///     Пароль.
    /// </summary>
    [MaxLength(PasswordConstraints.MaxLength)]
    public required string Password { get; set; }

    /// <summary>
    ///     Аватар пользователя.
    /// </summary>
    public IFormFile? Avatar { get; set; }
}