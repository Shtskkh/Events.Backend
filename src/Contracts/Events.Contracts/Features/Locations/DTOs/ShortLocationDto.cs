namespace Events.Contracts.Features.Locations.DTOs;

/// <summary>
///     Краткая информация о локации.
/// </summary>
public class ShortLocationDto
{
    /// <summary>
    ///     Идентификатор.
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    ///     Название локации.
    /// </summary>
    public string Title { get; init; } = null!;

    /// <summary>
    ///     Адрес локации.
    /// </summary>
    public string Address { get; init; } = null!;
}