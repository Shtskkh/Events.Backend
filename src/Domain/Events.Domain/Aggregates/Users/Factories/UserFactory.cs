using Events.Domain.Aggregates.Users.ValueObjects;
using Events.Domain.Shared.ValueObjects;

namespace Events.Domain.Aggregates.Users.Factories;

/// <summary>
///     Фабрика пользователя.
/// </summary>
public static class UserFactory
{
    /// <summary>
    /// </summary>
    /// <param name="lastName">Фамилия.</param>
    /// <param name="firstName">Имя.</param>
    /// <param name="email">Почтовый адрес.</param>
    /// <param name="password">Пароль.</param>
    /// <param name="role">Роль.</param>
    /// <param name="avatarFilename">Название файла аватара.</param>
    /// <param name="patronymic">Отчество</param>
    /// <returns>Объект сущности пользователя.</returns>
    public static User Create(
        string lastName,
        string firstName,
        string email,
        string password,
        UserRole role,
        string? avatarFilename = null,
        string? patronymic = null)
    {
        var id = Guid.NewGuid();
        var personNameVo = new PersonName(lastName, firstName, patronymic);
        var emailVo = new Email(email);
        var passwordVo = new Password(password);

        return new User(id, personNameVo, emailVo, passwordVo, role, avatarFilename);
    }
}