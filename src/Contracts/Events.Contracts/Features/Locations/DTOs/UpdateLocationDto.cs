using System.ComponentModel.DataAnnotations;
using Events.Domain.Shared;

namespace Events.Contracts.Features.Locations.DTOs;

/// <summary>
///     Модель обновления локации.
/// </summary>
public class UpdateLocationDto
{
    /// <summary>
    ///     Название локации.
    /// </summary>
    [MinLength(DomainConstraints.Location.Title.MinLength)]
    [MaxLength(DomainConstraints.Location.Title.MaxLength)]
    public string? Title { get; set; }

    /// <summary>
    ///     Адрес локации.
    /// </summary>
    [MinLength(DomainConstraints.Location.Address.MinLength)]
    [MaxLength(DomainConstraints.Location.Address.MaxLength)]
    public string? Address { get; set; }
}