using System.ComponentModel.DataAnnotations;
using Events.Domain.Shared;
using Microsoft.AspNetCore.Http;

namespace Events.Contracts.Features.Users;

/// <summary>
///     Форма создания пользователя.
/// </summary>
public class CreateUserDto
{
    /// <summary>
    ///     Имя.
    /// </summary>
    [MinLength(1)]
    [MaxLength(DomainConstraints.User.PersonName.MaxLength)]
    public required string FirstName { get; set; }

    /// <summary>
    ///     Фамилия.
    /// </summary>
    [MinLength(1)]
    [MaxLength(DomainConstraints.User.PersonName.MaxLength)]
    public required string LastName { get; set; }

    /// <summary>
    ///     Отчество.
    /// </summary>
    [MinLength(1)]
    [MaxLength(DomainConstraints.User.PersonName.MaxLength)]
    public string? Patronymic { get; set; }

    /// <summary>
    ///     Почтовый адрес.
    /// </summary>
    [MinLength(1)]
    [MaxLength(DomainConstraints.Email.MaxLength)]
    public required string Email { get; set; }

    /// <summary>
    ///     Пароль.
    /// </summary>
    [MinLength(1)]
    [MaxLength(DomainConstraints.Password.MaxLength)]
    public required string Password { get; set; }

    /// <summary>
    ///     Аватар пользователя.
    /// </summary>
    public IFormFile? Avatar { get; set; }
}