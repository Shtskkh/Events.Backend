using System.ComponentModel.DataAnnotations;
using Events.Domain.Aggregates.LocationAggregate.Constraints;
using Microsoft.AspNetCore.Http;

namespace Events.Contracts.Locations;

/// <summary>
///     Модель создания локации.
/// </summary>
public sealed record CreateLocationDto
{
    /// <summary>
    ///     Название.
    /// </summary>
    [MaxLength(LocationConstraints.Title.MaxLength)]
    public required string Title { get; init; }

    /// <summary>
    ///     Адрес.
    /// </summary>
    [MaxLength(LocationConstraints.Address.MaxLength)]
    public required string Address { get; init; }

    /// <summary>
    ///     Фото.
    /// </summary>
    public IFormFileCollection? Photos { get; set; }
}