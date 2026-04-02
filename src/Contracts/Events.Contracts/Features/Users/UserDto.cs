using Events.Contracts.Features.Files;

namespace Events.Contracts.Features.Users;

/// <summary>
///     Информация о пользователе.
/// </summary>
public class UserDto
{
    /// <summary>
    ///     Идентификатор.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    ///     Фамилия.
    /// </summary>
    public string LastName { get; set; } = null!;

    /// <summary>
    ///     Имя.
    /// </summary>
    public string FirstName { get; set; } = null!;

    /// <summary>
    ///     Отчество.
    /// </summary>
    public string? Patronymic { get; set; }

    /// <summary>
    ///     Почтовый адрес пользователя.
    /// </summary>
    public string Email { get; set; } = null!;

    /// <summary>
    ///     Информация об аватаре пользователя.
    /// </summary>
    public S3FileDto? AvatarInfo { get; set; }
}