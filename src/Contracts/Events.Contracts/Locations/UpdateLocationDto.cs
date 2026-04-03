using System.ComponentModel.DataAnnotations;
using Events.Domain.Shared;

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
    [MaxLength(DomainConstraints.Location.Title.MaxLength)]
    public string? Title { get; set; }

    /// <summary>
    ///     Адрес локации.
    /// </summary>
    [MinLength(1)]
    [MaxLength(DomainConstraints.Location.Address.MaxLength)]
    public string? Address { get; set; }
}