using Events.Domain.Aggregates.LocationAggregate.ValueObjects;

namespace Events.Domain.Aggregates.LocationAggregate.Factories;

/// <inheritdoc />
public class LocationFactory : ILocationFactory
{
    /// <inheritdoc />
    public Location Create(string title, string address)
    {
        var titleVo = new LocationTitle(title);
        var addressVo = new LocationAddress(address);

        return new Location(0, titleVo, addressVo);
    }
}