using System.ComponentModel.DataAnnotations;
using Events.Domain.Aggregates.Locations.ValueObjects.Locations;
using Events.Domain.Shared.ValueObjects;

namespace Events.Contracts.Locations;

/// <summary>
///     Модель обновления локации.
/// </summary>
public sealed record UpdateLocationDto
{
    /// <summary>
    ///     Название локации.
    /// </summary>
    [MaxLength(LocationTitle.MaxLength)]
    public string? Title { get; init; }

    /// <summary>
    ///     Адрес локации.
    /// </summary>
    [MaxLength(LocationAddress.MaxLength)]
    public string? Address { get; init; }

    /// <summary>
    ///     Упорядоченный список фотографий.
    /// </summary>
    public IReadOnlyCollection<PhotoEntry>? Photos { get; init; }
}