using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Domain.Shared.Interfaces;
using Events.Domain.Shared.ValueObjects;

namespace Events.Domain.Aggregates.UserAggregate;

/// <summary>
///     Сущность пользователя.
/// </summary>
public class User : Entity<Guid>, IAggregateRoot, IAuditable
{
    private User()
    {
    }

    /// <summary>
    ///     Конструктор.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="email">Почтовый адрес.</param>
    /// <param name="userRole">Роль.</param>
    public User(Guid id, Email email, UserRole userRole) : base(id)
    {
        Email = email;
        Role = userRole;

        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    /// <summary>
    ///     Почтовый адрес пользователя.
    /// </summary>
    public Email Email { get; private set; } = null!;

    /// <summary>
    ///     Роль пользователя.
    /// </summary>
    public UserRole Role { get; private set; } = null!;

    /// <inheritdoc />
    public DateTime CreatedAt { get; }

    /// <inheritdoc />
    public DateTime UpdatedAt { get; }

    /// <summary>
    ///     Изменить почтовый адрес.
    /// </summary>
    /// <param name="newEmail">Новый почтовый адрес.</param>
    public void ChangeEmail(string newEmail)
    {
        var email = new Email(newEmail);

        if (Email == email)
            throw new DomainException(DomainErrorMessages.User.EmailAlreadyInUse);

        Email = email;
    }

    /// <summary>
    ///     Изменить роль пользователя.
    /// </summary>
    /// <param name="role">Новая роль.</param>
    public void ChangeRole(UserRole role)
    {
        if (Role == role)
            throw new InvalidOperationException(DomainErrorMessages.User.RoleAlreadyAssigned);

        Role = role;
    }
}