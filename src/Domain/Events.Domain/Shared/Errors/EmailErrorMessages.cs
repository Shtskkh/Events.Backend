namespace Events.Domain.Shared.Errors;

/// <summary>
///     Ошибки почтового адреса.
/// </summary>
public static class EmailErrorMessages
{
    public const string Invalid = "Неверный формат почтового адреса.";

    public static readonly string GreaterThanMaxLength =
        $"Длина почтового адреса больше максимальной длины в {DomainConstraints.Email.MaxLength} символ(-ов).";
}