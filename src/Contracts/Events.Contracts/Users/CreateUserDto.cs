using System.ComponentModel.DataAnnotations;
using Events.Domain.Aggregates.UserAggregate.Constraints;
using Events.Domain.Shared.Constraints;
using Microsoft.AspNetCore.Http;

namespace Events.Contracts.Users;

/// <summary>
///     Форма создания пользователя.
/// </summary>
public class CreateUserDto
{
    /// <summary>
    ///     Имя.
    /// </summary>
    [MinLength(1)]
    [MaxLength(UserConstrains.PersonName.MaxLength)]
    public required string FirstName { get; set; }

    /// <summary>
    ///     Фамилия.
    /// </summary>
    [MinLength(1)]
    [MaxLength(UserConstrains.PersonName.MaxLength)]
    public required string LastName { get; set; }

    /// <summary>
    ///     Отчество.
    /// </summary>
    [MinLength(1)]
    [MaxLength(UserConstrains.PersonName.MaxLength)]
    public string? Patronymic { get; set; }

    /// <summary>
    ///     Почтовый адрес.
    /// </summary>
    [MinLength(1)]
    [MaxLength(EmailConstraints.MaxLength)]
    public required string Email { get; set; }

    /// <summary>
    ///     Пароль.
    /// </summary>
    [MinLength(1)]
    [MaxLength(PasswordConstraints.MaxLength)]
    public required string Password { get; set; }

    /// <summary>
    ///     Аватар пользователя.
    /// </summary>
    public IFormFile? Avatar { get; set; }
}