namespace Events.Contracts.Places;

/// <summary>
///     Забронированное помещение.
/// </summary>
public sealed record BookedPlaceDto
{
    /// <summary>
    ///     ID помещения.
    /// </summary>
    public int PlaceId { get; init; }

    /// <summary>
    ///     Номер помещения.
    /// </summary>
    public string Number { get; init; } = null!;
}