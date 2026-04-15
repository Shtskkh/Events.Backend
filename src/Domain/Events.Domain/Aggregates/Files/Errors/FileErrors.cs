using Events.Domain.Shared;

namespace Events.Domain.Aggregates.Files.Errors;

public static class FileErrors
{
    public static Error NotFoundAny => new("File.NotFoundAny", "Файлы не найдены.");

    public static Error FileNotFoundByName(string filename)
    {
        return new Error("File.NotFoundByName", $"Файл с названием: {filename} не найден.");
    }
}