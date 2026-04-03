using Events.Contracts.Files;

namespace Events.Contracts.Users;

/// <summary>
///     Краткая информация о пользователе.
/// </summary>
public class ShortUserDto
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
    ///     Информация об аватаре пользователя.
    /// </summary>
    public S3FileDto? AvatarInfo { get; set; }
}