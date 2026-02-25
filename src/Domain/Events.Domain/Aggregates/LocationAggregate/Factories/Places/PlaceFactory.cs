using Events.Domain.Aggregates.LocationAggregate.ValueObjects.Place;

namespace Events.Domain.Aggregates.LocationAggregate.Factories.Places;

/// <inheritdoc />
public class PlaceFactory : IPlaceFactory
{
    /// <inheritdoc />
    public Place Create(string number, PlaceType type, string? title = null)
    {
        var numberVo = new PlaceNumber(number);
        var titleVo = title == null ? null : new PlaceTitle(title);

        var place = new Place(default, numberVo, type, titleVo);
        return place;
    }
}