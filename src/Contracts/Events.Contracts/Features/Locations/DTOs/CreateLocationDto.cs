namespace Events.Contracts.Features.Locations.DTOs;

/// <summary>
///     Модель создания локации.
/// </summary>
public class CreateLocationDto
{
    /// <summary>
    ///     Название локации.
    /// </summary>
    public required string Title { get; init; }

    /// <summary>
    ///     Адрес локации.
    /// </summary>
    public required string Address { get; init; }
}