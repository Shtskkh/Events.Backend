using Events.Domain.Aggregates.LocationAggregate.ValueObjects.Places;

namespace Events.Domain.Aggregates.LocationAggregate.Factories.Places;

/// <summary>
///     Фабрика создания помещения.
/// </summary>
public static class PlaceFactory
{
    /// <summary>
    ///     Создать помещение.
    /// </summary>
    /// <param name="number">Номер помещения.</param>
    /// <param name="capacity">Вместимость помещения.</param>
    /// <param name="type">Тип помещения.</param>
    /// <param name="locationId">ID локации.</param>
    /// <param name="title">Название помещения.</param>
    /// <returns>Объект помещения.</returns>
    public static Place Create(string number, int capacity, PlaceType type, int locationId, string? title = null)
    {
        var numberVo = new PlaceNumber(number);
        var titleVo = title == null ? null : new PlaceTitle(title);
        var capacityVo = new PlaceCapacity(capacity);

        var place = new Place(default, numberVo, capacityVo, type, locationId, titleVo);
        return place;
    }
}