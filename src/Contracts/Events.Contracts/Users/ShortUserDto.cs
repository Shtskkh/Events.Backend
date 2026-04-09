using Events.Contracts.Files;

namespace Events.Contracts.Users;

/// <summary>
///     Краткая информация о пользователе.
/// </summary>
public sealed record ShortUserDto
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
    ///     Информация об аватаре пользователя.
    /// </summary>
    public S3FileDto? AvatarInfo { get; init; }
}