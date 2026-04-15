using Events.Domain.Shared.ValueObjects;

namespace Events.Domain.Shared.Errors;

public static class PasswordErrors
{
    public static Error OldPasswordDoesNotMatch =>
        new("Password.OldPasswordDoesNotMatch", "Прежний пароль не совпадает.");

    public static Error Invalid => new("Password.Invalid",
        $"Пароль не может содержать следующие символы: " +
        $"{string.Join(", ", Password.InvalidCharacters.Select(FormatChar))}.");

    public static Error LessThanMinLength => new("Password.LessThanMinLength",
        $"Длина пароля меньше минимальной длины в {Password.MinLength} символ(-ов).");

    public static Error GreaterThanMaxLength => new("Password.GreaterThanMaxLength",
        $"Длина пароля больше максимальной длины в {Password.MaxLength} символ(-ов).");

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