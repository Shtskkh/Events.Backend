namespace Events.Contracts.Places.PlacesTypes;

/// <summary>
///     Тип помещения.
/// </summary>
public sealed record PlaceTypeDto
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