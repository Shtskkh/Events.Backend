using System.ComponentModel.DataAnnotations;
using Events.Domain.Shared;

namespace Events.Contracts.Features.Locations.Places;

/// <summary>
///     Модель обновления помещения.
/// </summary>
public class UpdatePlaceDto
{
    /// <summary>
    ///     Название.
    /// </summary>
    [MinLength(DomainConstraints.Place.Title.MinLength)]
    [MaxLength(DomainConstraints.Place.Title.MaxLength)]
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