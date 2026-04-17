using Events.Domain.Shared;

namespace Events.Domain.Aggregates.Events.Errors;

public static class TagErrors
{
    public static Error ContainsWhiteSpace => new("Tag.ContainsWhiteSpace", "Тэг не может содержать пробелов.");

    public static Error GreaterThanMaxLength =>
        new("Tag.GreaterThanMaxLength", $"Тэг больше максимальной длинны в {Tag.MaxLength}");
}