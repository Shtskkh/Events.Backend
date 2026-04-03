using System.ComponentModel.DataAnnotations;
using Events.Domain.Aggregates.LocationAggregate.Constraints;

namespace Events.Contracts.Locations;

/// <summary>
///     Модель обновления локации.
/// </summary>
public class UpdateLocationDto
{
    /// <summary>
    ///     Название локации.
    /// </summary>
    [MinLength(1)]
    [MaxLength(LocationConstraints.Title.MaxLength)]
    public string? Title { get; set; }

    /// <summary>
    ///     Адрес локации.
    /// </summary>
    [MinLength(1)]
    [MaxLength(LocationConstraints.Address.MaxLength)]
    public string? Address { get; set; }
}