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
    /// <param name="type">Тип помещения.</param>
    /// <param name="title">Название помещения.</param>
    /// <returns>Объект помещения.</returns>
    public static Place Create(string number, PlaceType type, string? title = null)
    {
        var numberVo = new PlaceNumber(number);
        var titleVo = title == null ? null : new PlaceTitle(title);

        var place = new Place(default, numberVo, type, titleVo);
        return place;
    }
}