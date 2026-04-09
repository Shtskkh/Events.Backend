namespace Events.Contracts.Files;

/// <summary>
///     Модель фото.
/// </summary>
public sealed record PhotoDto
{
    /// <summary>
    ///     Название файла.
    /// </summary>
    public string Filename { get; init; } = null!;

    /// <summary>
    ///     Порядковый номер для отображения.
    /// </summary>
    public int Order { get; init; }
}