using Events.Domain.Aggregates.Users.ValueObjects;
using Events.Domain.Shared;

namespace Events.Domain.Aggregates.Users.Errors;

public static class PersonNameErrors
{
    public static Error FirstNameGreaterThanMaxLength => new("PersonName.FirstNameGreaterThanMaxLength",
        $"Имя больше максимальной длины в {PersonName.MaxLength} символ(-ов).");

    public static Error LastNameGreaterThanMaxLength => new("PersonName.LastNameGreaterThanMaxLength",
        $"Фамилия больше максимальной длины в {PersonName.MaxLength} символ(-ов).");

    public static Error PatronymicGreaterThanMaxLength => new("PersonName.PatronymicGreaterThanMaxLength",
        $"Отчество больше максимальной длины в {PersonName.MaxLength} символ(-ов).");
}