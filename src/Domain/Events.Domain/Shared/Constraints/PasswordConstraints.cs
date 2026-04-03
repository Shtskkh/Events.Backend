namespace Events.Domain.Shared.Constraints;

/// <summary>
///     Константы паролей.
/// </summary>
public static class PasswordConstraints
{
    /// <summary>
    ///     Минимальная длина.
    /// </summary>
    public const int MinLength = 6;

    /// <summary>
    ///     Максимальная длина.
    /// </summary>
    public const int MaxLength = 512;

    /// <summary>
    ///     Недопустимые символы.
    /// </summary>
    public static readonly char[] InvalidCharacters = [' ', '\t', '\n'];
}