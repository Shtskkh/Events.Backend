namespace Events.Contracts.Files;

/// <summary>
///     Информация о файле из S3.
/// </summary>
public sealed record S3FileDto
{
    /// <summary>
    ///     Название bucket.
    /// </summary>
    public string Bucket { get; init; } = null!;

    /// <summary>
    ///     Название файла.
    /// </summary>
    public string Key { get; init; } = null!;
}