using Events.Domain.Shared;

namespace Events.Domain.Aggregates.Events.Errors;

public static class TagErrors
{
    public static Error ContainsWhiteSpace => new("Tag.ContainsWhiteSpace", "Тэг не может содержать пробелов.");

    public static Error GreaterThanMaxLength =>
        new("Tag.GreaterThanMaxLength", $"Тэг больше максимальной длинны в {Tag.MaxLength}");

    public static Error AlreadyAssigned(Tag tag)
    {
        return new Error("Tag.AlreadyAssigned", $"Тэг: {tag.Value} уже добавлен.");
    }

    public static Error NotFoundById(int tagId)
    {
        return new Error("Tag.NotFoundById", $"Тэг с ID: {tagId} не найден.");
    }
}