using Events.Contracts.Files;

namespace Events.Contracts.Locations;

/// <summary>
///     Краткая информация о локации.
/// </summary>
public class ShortLocationDto
{
    /// <summary>
    ///     Идентификатор.
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    ///     Название.
    /// </summary>
    public string Title { get; init; } = null!;

    /// <summary>
    ///     Адрес.
    /// </summary>
    public string Address { get; init; } = null!;

    /// <summary>
    ///     Превью.
    /// </summary>
    public S3FileDto? Preview { get; init; }
}