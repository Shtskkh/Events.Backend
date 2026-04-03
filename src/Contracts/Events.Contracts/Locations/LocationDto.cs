namespace Events.Contracts.Locations;

/// <summary>
///     Информация о локации.
/// </summary>
public class LocationDto
{
    /// <summary>
    ///     Идентификатор.
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    ///     Название локации.
    /// </summary>
    public string Title { get; init; } = null!;

    /// <summary>
    ///     Адрес локации.
    /// </summary>
    public string Address { get; init; } = null!;
}