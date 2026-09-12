namespace Events.Contracts.Files;

/// <summary>
///     Файл.
/// </summary>
public interface IFile
{
    /// <summary>
    ///     Поток файла.
    /// </summary>
    public Stream Content { get; set; }

    /// <summary>
    ///     Тип файла.
    /// </summary>
    public string ContentType { get; set; }

    /// <summary>
    ///     Название файла.
    /// </summary>
    public string Filename { get; set; }

    /// <summary>
    ///     Размер файла.
    /// </summary>
    public long Length { get; set; }
}