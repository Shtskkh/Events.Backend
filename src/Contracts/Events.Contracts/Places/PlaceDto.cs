using Events.Contracts.Files;

namespace Events.Contracts.Places;

/// <summary>
///     Информация о помещении.
/// </summary>
public class PlaceDto
{
    /// <summary>
    ///     Идентификатор.
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    ///     Номер.
    /// </summary>
    public string Number { get; init; } = null!;

    /// <summary>
    ///     Вместимость.
    /// </summary>
    public int Capacity { get; init; }

    /// <summary>
    ///     Тип.
    /// </summary>
    public string Type { get; init; } = null!;

    /// <summary>
    ///     Название.
    /// </summary>
    public string? Title { get; init; }
    
    /// <summary>
    ///     Bucket фото.
    /// </summary>
    public string? PhotosBucket { get; init; }

    /// <summary>
    ///     Фото.
    /// </summary>
    public IReadOnlyCollection<PhotoDto>? Photos { get; init; }
}