using Events.Domain.Aggregates.Users.Constraints;

namespace Events.Domain.Aggregates.Users.Errors;

/// <summary>
///     Ошибки пользователей.
/// </summary>
public static class UserErrorMessages
{
    public const string Unauthorized = "Неверный почтовый адрес или пароль";
    public const string RoleAlreadyAssigned = "Роль уже присвоена.";
    public const string EmailAlreadyInUse = "Почтовый адрес уже используется.";

    public static string UserNotFoundById(Guid userId)
    {
        return $"Пользователь с ID: {userId} не найден.";
    }

    /// <summary>
    ///     Ошибки ролей пользователей.
    /// </summary>
    public static class Role
    {
        public static readonly string GreaterThanMaxLength =
            $"Название роли пользователя больше максимальной длины в {UserConstrains.Role.MaxLength} символ(-ов).";

        public static string RoleNotFoundById(int roleId)
        {
            return $"Роль с ID: {roleId} не найдена.";
        }
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