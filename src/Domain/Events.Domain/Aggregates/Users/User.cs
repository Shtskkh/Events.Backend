using Events.Domain.Aggregates.Users.Errors;
using Events.Domain.Aggregates.Users.ValueObjects;
using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Domain.Shared.Interfaces;
using Events.Domain.Shared.ValueObjects;

namespace Events.Domain.Aggregates.Users;

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
    /// <param name="personName">ФИО пользователя.</param>
    /// <param name="email">Почтовый адрес.</param>
    /// <param name="password">Пароль.</param>
    /// <param name="userRole">Роль.</param>
    /// <param name="avatarFilename">Название файла аватара.</param>
    public User(
        Guid id,
        PersonName personName,
        Email email,
        Password password,
        UserRole userRole,
        string? avatarFilename = null) : base(id)
    {
        PersonName = personName;
        Email = email;
        Role = userRole;
        Password = password;
        AvatarFilename = avatarFilename;
        CreatedAt = DateTimeOffset.UtcNow;
        UpdatedAt = DateTimeOffset.UtcNow;
    }

    /// <summary>
    ///     ФИО пользователя.
    /// </summary>
    public PersonName PersonName { get; private set; } = null!;

    /// <summary>
    ///     Почтовый адрес пользователя.
    /// </summary>
    public Email Email { get; private set; } = null!;

    /// <summary>
    ///     Пароль пользователя.
    /// </summary>
    public Password Password { get; private set; } = null!;

    /// <summary>
    ///     Роль пользователя.
    /// </summary>
    public UserRole Role { get; private set; } = null!;

    /// <summary>
    ///     Название файла аватара пользователя.
    /// </summary>
    public string? AvatarFilename { get; private set; }

    /// <inheritdoc />
    public DateTimeOffset CreatedAt { get; }

    /// <inheritdoc />
    public DateTimeOffset UpdatedAt { get; }

    /// <summary>
    ///     Изменить ФИО пользователя.
    /// </summary>
    /// <param name="firstName">Имя.</param>
    /// <param name="lastName">Фамилия.</param>
    /// <param name="patronymic">Отчество.</param>
    public void ChangePersonName(string? firstName, string? lastName, string? patronymic = null)
    {
        PersonName = new PersonName(
            firstName ?? PersonName.FirstName,
            lastName ?? PersonName.LastName,
            patronymic ?? PersonName.Patronymic);
    }

    /// <summary>
    ///     Изменить почтовый адрес.
    /// </summary>
    /// <param name="newEmail">Новый почтовый адрес.</param>
    public void ChangeEmail(string newEmail)
    {
        var email = new Email(newEmail);

        if (Email == email)
            throw new DomainException(UserErrors.EmailAlreadyInUse);

        Email = email;
    }

    /// <summary>
    ///     Изменить пароль.
    /// </summary>
    /// <param name="newPassword">Новый пароль.</param>
    public void ChangePassword(string newPassword)
    {
        Password = new Password(newPassword);
    }

    /// <summary>
    ///     Изменить роль пользователя.
    /// </summary>
    /// <param name="role">Новая роль.</param>
    public void ChangeRole(UserRole role)
    {
        if (Role == role)
            throw new DomainException(UserErrors.RoleAlreadyAssigned);

        Role = role;
    }

    public void ChangeAvatar(string avatarFilename)
    {
        AvatarFilename = avatarFilename;
    }
}