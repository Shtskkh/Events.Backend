namespace Events.Domain.Shared.Errors;

/// <summary>
///     Ошибки фото.
/// </summary>
public static class PhotoErrorMessages
{
    public const string NotFound = "Фотография не найдена.";
    public const string AlreadyExists = "Фотография уже существует.";
    public const string InvalidOrder = "Порядок фотографии не может быть отрицательным.";
    public const string FileNameNullOrWhiteSpace = "Название файла фотографии не может быть пустым.";
}