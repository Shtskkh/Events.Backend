using Events.Contracts.Files;

namespace Events.Contracts.Locations;

/// <summary>
///     Информация о локации.
/// </summary>
public sealed record LocationDto
{
    /// <summary>
    ///     Идентификатор.
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    ///     Название локации.
    /// </summary>
    public string Title { get; init; } = null!;

    /// <summary>
    ///     Адрес локации.
    /// </summary>
    public string Address { get; init; } = null!;

    /// <summary>
    ///     Bucket фото.
    /// </summary>
    public string? PhotosBucket { get; init; }

    /// <summary>
    ///     Фото.
    /// </summary>
    public IReadOnlyCollection<PhotoDto>? Photos { get; init; }
}