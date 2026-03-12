namespace Events.Contracts.Features.Locations.Places;

/// <summary>
///     Краткая информация о помещении.
/// </summary>
public class ShortPlaceDto
{
    /// <summary>
    ///     Идентификатор.
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    ///     Номер.
    /// </summary>
    public string Number { get; init; } = null!;

    /// <summary>
    ///     Вместимость.
    /// </summary>
    public int Capacity { get; init; }

    /// <summary>
    ///     Тип.
    /// </summary>
    public string Type { get; init; } = null!;

    /// <summary>
    ///     Название.
    /// </summary>
    public string? Title { get; init; }
}