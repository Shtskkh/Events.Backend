namespace Events.Contracts.Features.Locations.PlacesTypes;

/// <summary>
///     Тип помещения.
/// </summary>
public class PlaceTypeDto
{
    /// <summary>
    ///     Идентификатор типа помещения.
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    ///     Название типа помещения.
    /// </summary>
    public string Title { get; init; } = null!;
}