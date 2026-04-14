using System.ComponentModel.DataAnnotations;
using Events.Domain.Aggregates.Locations.Constraints;
using Microsoft.AspNetCore.Http;

namespace Events.Contracts.Places;

/// <summary>
///     Модель создания помещения.
/// </summary>
public sealed record CreatePlaceDto
{
    /// <summary>
    ///     Номер.
    /// </summary>
    [MaxLength(PlaceConstraints.Number.MaxLength)]
    public required string Number { get; init; }

    /// <summary>
    ///     Вместимость.
    /// </summary>
    [Range(1, int.MaxValue)]
    public required int Capacity { get; init; }

    /// <summary>
    ///     Тип.
    /// </summary>
    [Range(1, int.MaxValue)]
    public required int Type { get; init; }

    /// <summary>
    ///     Название.
    /// </summary>
    [MinLength(1)]
    [MaxLength(PlaceConstraints.Title.MaxLength)]
    public string? Title { get; init; }

    /// <summary>
    ///     Фото.
    /// </summary>
    public IFormFileCollection? Photos { get; init; }
}