namespace Events.Contracts.Features.Locations.Places;

/// <summary>
///     Модель обновления помещения.
/// </summary>
public class UpdatePlaceDto
{
    /// <summary>
    ///     Название помещения.
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    ///     Тип помещения.
    /// </summary>
    public int? Type { get; set; }
}