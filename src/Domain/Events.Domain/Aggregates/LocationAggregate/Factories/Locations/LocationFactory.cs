using Events.Domain.Aggregates.LocationAggregate.ValueObjects.Locations;

namespace Events.Domain.Aggregates.LocationAggregate.Factories.Locations;

/// <inheritdoc />
public class LocationFactory : ILocationFactory
{
    /// <inheritdoc />
    public Location Create(string title, string address)
    {
        var titleVo = new LocationTitle(title);
        var addressVo = new LocationAddress(address);

        return new Location(default, titleVo, addressVo);
    }
}