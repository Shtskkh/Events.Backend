using System.ComponentModel.DataAnnotations;
using Events.Domain.Shared;

namespace Events.Contracts.Places;

/// <summary>
///     Модель обновления помещения.
/// </summary>
public class UpdatePlaceDto
{
    /// <summary>
    ///     Название.
    /// </summary>
    [MinLength(1)]
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