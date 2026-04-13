namespace Events.Domain.Aggregates.Users.Constraints;

/// <summary>
///     Константы пользователей.
/// </summary>
public static class UserConstrains
{
    /// <summary>
    ///     Константы ролей.
    /// </summary>
    public static class Role
    {
        public const int MaxLength = 16;
    }

    /// <summary>
    ///     Константы ФИО.
    /// </summary>
    public static class PersonName
    {
        public const int MaxLength = 64;
    }
}