namespace Events.Contracts.Events.EventsFormats;

/// <summary>
///     Информация о формате мероприятия.
/// </summary>
public sealed record EventFormatDto
{
    /// <summary>
    ///     Идентификатор.
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    ///     Название.
    /// </summary>
    public string Title { get; init; } = null!;
}