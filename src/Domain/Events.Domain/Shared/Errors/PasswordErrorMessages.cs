using Events.Domain.Shared.Constraints;

namespace Events.Domain.Shared.Errors;

/// <summary>
///     Ошибки паролей.
/// </summary>
public static class PasswordErrorMessages
{
    public const string OldPasswordDoesNotMatch = "Прежний пароль не совпадает.";

    public static readonly string Invalid =
        $"Пароль не может содержать следующие символы: " +
        $"{string.Join(", ", PasswordConstraints.InvalidCharacters.Select(FormatChar))}.";

    public static readonly string LessThanMinLength =
        $"Длина пароля меньше минимальной длины в {PasswordConstraints.MinLength} символ(-ов).";

    public static readonly string GreaterThanMaxLength =
        $"Длина пароля больше максимальной длины в {PasswordConstraints.MaxLength} символ(-ов).";

    /// <summary>
    ///     Вспомогательный метод для ошибки неправильного пароля.
    /// </summary>
    /// <param name="c">Символ.</param>
    /// <returns>Строковое представление неправильного символа.</returns>
    private static string FormatChar(char c)
    {
        return c switch
        {
            ' ' => "пробел",
            '\t' => "табуляция",
            '\n' => "перенос строки",
            _ => c.ToString()
        };
    }
}