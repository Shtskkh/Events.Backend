using Events.Contracts.Files;

namespace Events.Contracts.Users;

/// <summary>
///     Информация о пользователе.
/// </summary>
public sealed record UserDto
{
    /// <summary>
    ///     Идентификатор.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    ///     Фамилия.
    /// </summary>
    public string LastName { get; init; } = null!;

    /// <summary>
    ///     Имя.
    /// </summary>
    public string FirstName { get; init; } = null!;

    /// <summary>
    ///     Отчество.
    /// </summary>
    public string? Patronymic { get; init; }

    /// <summary>
    ///     Почтовый адрес пользователя.
    /// </summary>
    public string Email { get; init; } = null!;

    /// <summary>
    ///     Информация об аватаре пользователя.
    /// </summary>
    public S3FileDto? AvatarInfo { get; init; }
}