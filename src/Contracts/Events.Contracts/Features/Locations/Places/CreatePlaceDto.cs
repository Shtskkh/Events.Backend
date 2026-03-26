using System.ComponentModel.DataAnnotations;
using Events.Domain.Shared;
using Microsoft.AspNetCore.Http;

namespace Events.Contracts.Features.Locations.Places;

/// <summary>
///     Модель создания помещения.
/// </summary>
public class CreatePlaceDto
{
    /// <summary>
    ///     Номер.
    /// </summary>
    [MinLength(DomainConstraints.Place.Number.MinLength)]
    [MaxLength(DomainConstraints.Place.Number.MaxLength)]
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
    [MinLength(DomainConstraints.Place.Title.MinLength)]
    [MaxLength(DomainConstraints.Place.Title.MaxLength)]
    public string? Title { get; init; }

    /// <summary>
    ///     Фото.
    /// </summary>
    public IFormFileCollection? Photos { get; init; }
}