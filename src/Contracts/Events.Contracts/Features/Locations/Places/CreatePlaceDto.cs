using System.ComponentModel.DataAnnotations;
using Events.Domain.Shared;

namespace Events.Contracts.Features.Locations.Places;

/// <summary>
///     Модель создания помещения.
/// </summary>
public class CreatePlaceDto
{
    /// <summary>
    ///     Номер помещения.
    /// </summary>
    [MinLength(DomainConstraints.Place.Number.MinLength)]
    [MaxLength(DomainConstraints.Place.Number.MaxLength)]
    public required string Number { get; init; }

    /// <summary>
    ///     Тип помещения.
    /// </summary>
    [Range(1, int.MaxValue)]
    public required int Type { get; init; }

    /// <summary>
    ///     Название помещения.
    /// </summary>
    [MinLength(DomainConstraints.Place.Title.MinLength)]
    [MaxLength(DomainConstraints.Place.Title.MaxLength)]
    public string? Title { get; init; }
}