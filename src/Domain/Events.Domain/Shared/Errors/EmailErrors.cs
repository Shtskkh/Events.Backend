using Events.Domain.Shared.ValueObjects;

namespace Events.Domain.Shared.Errors;

public static class EmailErrors
{
    public static Error Invalid => new("Email.Invalid", "Неверный формат почтового адреса.");

    public static Error GreaterThanMaxLength => new("Email.GreaterThanMaxLength",
        $"Длина почтового адреса больше максимальной длины в {Email.MaxLength} символ(-ов).");
}