namespace Events.Domain.Shared.Errors;

public static class PhotoErrors
{
    public static Error InvalidOrder => new("Photo.InvalidOrder", "Порядок фотографии не может быть отрицательным.");

    public static Error FileNameNullOrWhiteSpace => new("Photo.FileNameNullOrWhiteSpace",
        "Название файла фотографии не может быть пустым.");

    public static Error InvalidEntry => new("Photo.InvalidEntry", "Переданы неверные параметры для фото.");

    public static Error AlreadyExists(string filename)
    {
        return new Error("Photo.AlreadyExists", $"Фотография с названием: {filename} уже существует.");
    }

    public static Error NotFound(string filename)
    {
        return new Error("Photo.NotFound", $"Фотография с названием: {filename} не найдена.");
    }
}