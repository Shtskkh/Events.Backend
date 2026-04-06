namespace Events.Application.Services.Features.Events.Commands.Create;

/// <summary>
///     Ошибки создания мероприятия.
/// </summary>
public static class CreateEventErrorMessages
{
    public const string PreviewFileSizeExceedsLimit = "Размер файла превью не должен превышать 5 МБ.";
    public const string PreviewFileContentTypeNotAllowed = "Тип файла превью не разрешён.";
}