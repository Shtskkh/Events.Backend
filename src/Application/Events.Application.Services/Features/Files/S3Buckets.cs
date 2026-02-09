namespace Events.Application.Services.Features.Files;

/// <summary>
///     S3 buckets.
/// </summary>
public static class S3Buckets
{
    /// <summary>
    ///     Превью изображения мероприятий.
    /// </summary>
    public const string EventPreviews = "events-previews";

    /// <summary>
    ///     Получить все buckets.
    /// </summary>
    /// <returns>
    ///     Постепенное возвращение строковых представлений buckets.
    /// </returns>
    public static IEnumerable<string> GetAll()
    {
        yield return EventPreviews;
    }
}