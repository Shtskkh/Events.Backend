using Events.Domain.Aggregates.Locations.ValueObjects.Locations;

namespace Events.Domain.Aggregates.Locations.Factories.Locations;

/// <summary>
///     Фабрика локации.
/// </summary>
public static class LocationFactory
{
    /// <summary>
    ///     Создать локацию.
    /// </summary>
    /// <param name="title">Название локации.</param>
    /// <param name="address">Адрес локации.</param>
    /// <returns>Объект локации.</returns>
    public static Location Create(string title, string address)
    {
        var titleVo = new LocationTitle(title);
        var addressVo = new LocationAddress(address);

        return new Location(default, titleVo, addressVo);
    }
}