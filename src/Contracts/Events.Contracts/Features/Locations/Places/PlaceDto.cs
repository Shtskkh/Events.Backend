namespace Events.Contracts.Features.Locations.Places;

/// <summary>
///     Информация о помещении.
/// </summary>
public class PlaceDto
{
    /// <summary>
    ///     Идентификатор.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    ///     Номер помещения.
    /// </summary>
    public string Number { get; set; } = null!;

    /// <summary>
    ///     Тип помещения.
    /// </summary>
    public string Type { get; set; } = null!;

    /// <summary>
    ///     Название помещения.
    /// </summary>
    public string? Title { get; set; }
}