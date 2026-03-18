namespace Events.Contracts.Features.Locations.Places;

/// <summary>
///     Забронированное помещение.
/// </summary>
public record BookedPlaceDto
{
    /// <summary>
    ///     ID помещения.
    /// </summary>
    public int PlaceId { get; init; }

    /// <summary>
    ///     Номер помещения.
    /// </summary>
    public string Number { get; init; }
}