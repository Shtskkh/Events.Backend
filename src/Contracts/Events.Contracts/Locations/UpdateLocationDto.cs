using System.ComponentModel.DataAnnotations;
using Events.Domain.Aggregates.LocationAggregate.Constraints;

namespace Events.Contracts.Locations;

/// <summary>
///     Модель обновления локации.
/// </summary>
public sealed record UpdateLocationDto
{
    /// <summary>
    ///     Название локации.
    /// </summary>
    [MaxLength(LocationConstraints.Title.MaxLength)]
    public string? Title { get; set; }

    /// <summary>
    ///     Адрес локации.
    /// </summary>
    [MaxLength(LocationConstraints.Address.MaxLength)]
    public string? Address { get; set; }
}