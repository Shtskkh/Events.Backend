using System.ComponentModel.DataAnnotations;
using Events.Contracts.Photos;
using Events.Domain.Aggregates.Locations.ValueObjects.Locations;

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
    ///     Если передан null, то фото не обновляются.
    ///     Если передан [] (пустой массив), то удаляются все фотографии.
    ///     Если передан массив с элементами, то происходит замена.
    /// </summary>
    public IReadOnlyCollection<PhotoEntryDto>? Photos { get; init; }
}