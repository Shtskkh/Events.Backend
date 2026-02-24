using System.ComponentModel.DataAnnotations;
using Events.Domain.Shared;

namespace Events.Contracts.Features.Locations.DTOs;

/// <summary>
///     Модель создания локации.
/// </summary>
public class CreateLocationDto
{
    /// <summary>
    ///     Название локации.
    /// </summary>
    [MinLength(DomainConstraints.Location.Title.MinLength)]
    [MaxLength(DomainConstraints.Location.Title.MaxLength)]
    public required string Title { get; init; }

    /// <summary>
    ///     Адрес локации.
    /// </summary>
    [MinLength(DomainConstraints.Location.Address.MinLength)]
    [MaxLength(DomainConstraints.Location.Address.MaxLength)]
    public required string Address { get; init; }
}