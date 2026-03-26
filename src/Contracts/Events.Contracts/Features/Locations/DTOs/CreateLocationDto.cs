using System.ComponentModel.DataAnnotations;
using Events.Domain.Shared;
using Microsoft.AspNetCore.Http;

namespace Events.Contracts.Features.Locations.DTOs;

/// <summary>
///     Модель создания локации.
/// </summary>
public class CreateLocationDto
{
    /// <summary>
    ///     Название.
    /// </summary>
    [MinLength(DomainConstraints.Location.Title.MinLength)]
    [MaxLength(DomainConstraints.Location.Title.MaxLength)]
    public required string Title { get; init; }

    /// <summary>
    ///     Адрес.
    /// </summary>
    [MinLength(DomainConstraints.Location.Address.MinLength)]
    [MaxLength(DomainConstraints.Location.Address.MaxLength)]
    public required string Address { get; init; }

    /// <summary>
    ///     Фото.
    /// </summary>
    public IFormFileCollection? Photos { get; set; }
}