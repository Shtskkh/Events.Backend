using System.ComponentModel.DataAnnotations;
using Events.Domain.Aggregates.Locations.ValueObjects.Locations;
using Microsoft.AspNetCore.Http;

namespace Events.Contracts.Locations;

/// <summary>
///     Форма создания локации.
/// </summary>
public sealed record CreateLocationDto
{
    /// <summary>
    ///     Название.
    /// </summary>
    [MaxLength(LocationTitle.MaxLength)]
    public required string Title { get; init; }

    /// <summary>
    ///     Адрес.
    /// </summary>
    [MaxLength(LocationAddress.MaxLength)]
    public required string Address { get; init; }

    /// <summary>
    ///     Фотографии (необязательно).
    /// </summary>
    public IFormFileCollection? Photos { get; set; }
}