using Microsoft.AspNetCore.Http;

namespace Events.Contracts.Users;

/// <summary>
///     Форма обновления пользователя.
/// </summary>
public sealed record UpdateUserDto
{
    /// <summary>
    ///     Фамилия.
    /// </summary>
    public string? LastName { get; init; }

    /// <summary>
    ///     Имя.
    /// </summary>
    public string? FirstName { get; init; }

    /// <summary>
    ///     Отчество.
    /// </summary>
    public string? Patronymic { get; init; }

    /// <summary>
    ///     ID роли.
    /// </summary>
    public int? RoleId { get; init; }

    /// <summary>
    ///     Аватар.
    /// </summary>
    public IFormFile? Avatar { get; init; }
}