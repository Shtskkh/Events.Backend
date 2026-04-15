using System.ComponentModel.DataAnnotations;
using Events.Domain.Aggregates.Locations.ValueObjects.Places;

namespace Events.Contracts.Places;

/// <summary>
///     Модель обновления помещения.
/// </summary>
public sealed record UpdatePlaceDto
{
    /// <summary>
    ///     Название.
    /// </summary>
    [MaxLength(PlaceTitle.MaxLength)]
    public string? Title { get; init; }

    /// <summary>
    ///     Тип.
    /// </summary>
    [Range(1, int.MaxValue)]
    public int? Type { get; init; }

    /// <summary>
    ///     Вместимость.
    /// </summary>
    [Range(1, int.MaxValue)]
    public int? Capacity { get; init; }
}