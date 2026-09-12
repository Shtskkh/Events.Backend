using Events.Contracts.Files;

namespace Events.Contracts.Places;

/// <summary>
///     Краткая информация о помещении.
/// </summary>
public sealed record ShortPlaceDto
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

    /// <summary>
    ///     Превью.
    /// </summary>
    public S3FileDto? Preview { get; init; }
}