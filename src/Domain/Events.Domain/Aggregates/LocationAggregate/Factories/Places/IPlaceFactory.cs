namespace Events.Domain.Aggregates.LocationAggregate.Factories.Places;

/// <summary>
///     Фабрика создания помещения.
/// </summary>
public interface IPlaceFactory
{
    /// <summary>
    ///     Создать помещение.
    /// </summary>
    /// <param name="number">Номер помещения.</param>
    /// <param name="type">Тип помещения.</param>
    /// <param name="title">Название помещения.</param>
    /// <returns>Объект помещения.</returns>
    Place Create
    (
        string number,
        PlaceType type,
        string? title = null
    );
}