using Events.Domain.Aggregates.UserAggregate.Constraints;

namespace Events.Domain.Aggregates.UserAggregate.Errors;

/// <summary>
///     Ошибки пользователей.
/// </summary>
public static class UserErrorMessages
{
    public const string RoleAlreadyAssigned = "Роль уже присвоена.";
    public const string EmailAlreadyInUse = "Почтовый адрес уже используется.";

    /// <summary>
    ///     Ошибки ролей пользователей.
    /// </summary>
    public static class Role
    {
        public static readonly string GreaterThanMaxLength =
            $"Название роли пользователя больше максимальной длины в {UserConstrains.Role.MaxLength} символ(-ов).";
    }

    /// <summary>
    ///     Ошибки ФИО пользователя.
    /// </summary>
    public static class PersonName
    {
        public static readonly string FirstNameGreaterThanMaxLength =
            $"Имя больше максимальной длины в {UserConstrains.PersonName.MaxLength} символ(-ов).";

        public static readonly string LastNameGreaterThanMaxLength =
            $"Фамилия больше максимальной длины в {UserConstrains.PersonName.MaxLength} символ(-ов).";

        public static readonly string PatronymicGreaterThanMaxLength =
            $"Отчество больше максимальной длины в {UserConstrains.PersonName.MaxLength} символ(-ов).";
    }
}