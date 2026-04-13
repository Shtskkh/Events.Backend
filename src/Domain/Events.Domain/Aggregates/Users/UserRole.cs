using Events.Domain.Aggregates.Users.Constraints;
using Events.Domain.Aggregates.Users.Errors;
using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Domain.Shared.ValueObjects;

namespace Events.Domain.Aggregates.Users;

/// <summary>
///     Сущность роли пользователя.
/// </summary>
public class UserRole : Entity<int>
{
    /// <summary>
    ///     Администратор.
    /// </summary>
    public static readonly UserRole Admin = new(1, "Администратор");

    /// <summary>
    ///     Пользователь.
    /// </summary>
    public static readonly UserRole User = new(2, "Пользователь");

    private UserRole()
    {
    }

    /// <summary>
    ///     Конструктор.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="title">Название роли.</param>
    /// <exception cref="DomainException">Ошибка правил домена.</exception>
    public UserRole(int id, string title) : base(id)
    {
        var value = new Text(title).Value;

        if (value.Length > UserConstrains.Role.MaxLength)
            throw new DomainException(UserErrorMessages.Role.GreaterThanMaxLength);

        Title = value;
    }

    /// <summary>
    ///     Название роли пользователя.
    /// </summary>
    public string Title { get; } = null!;
}