namespace Events.Contracts.Places;

/// <summary>
///     Модель доступных помещений.
/// </summary>
public sealed record PlaceAvailabilityDto
{
    /// <summary>
    ///     ID.
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
    ///     Флаг доступности.
    /// </summary>
    public bool IsAvailable { get; init; }

    /// <summary>
    ///     Название.
    /// </summary>
    public string? Title { get; init; }
}