namespace Events.Contracts.Events;

/// <summary>
///     Плейсхолдер мероприятия.
/// </summary>
public sealed record EventPlaceholderDto
{
    /// <summary>
    ///     Название файла плейсхолдера.
    /// </summary>
    public string Key { get; init; } = null!;
}