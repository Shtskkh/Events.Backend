namespace Events.Domain.SeedWorks;

/// <summary>
///     Интерфейс файловой сущности.
/// </summary>
public interface IFileEntity
{
    /// <summary>
    ///     Название файла.
    /// </summary>
    Guid Name { get; set; }

    /// <summary>
    ///     Контент файла.
    /// </summary>
    byte[] Content { get; set; }

    /// <summary>
    ///     Тип контента.
    /// </summary>
    string ContentType { get; set; }

    /// <summary>
    ///     Размер файла.
    /// </summary>
    int Size { get; set; }
}