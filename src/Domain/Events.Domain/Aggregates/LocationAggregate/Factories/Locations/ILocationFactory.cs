namespace Events.Domain.Aggregates.LocationAggregate.Factories.Locations;

/// <summary>
///     Фабрика локации.
/// </summary>
public interface ILocationFactory
{
    /// <summary>
    ///     Создать локацию.
    /// </summary>
    /// <param name="title">Название локации.</param>
    /// <param name="address">Адрес локации.</param>
    /// <returns>Объект локации.</returns>
    public Location Create(string title, string address);
}