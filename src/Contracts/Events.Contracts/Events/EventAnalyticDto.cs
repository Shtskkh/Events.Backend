using Events.Contracts.Analytics;

namespace Events.Contracts.Events;

/// <summary>
///     Модель аналитики мероприятия.
/// </summary>
public sealed record EventAnalyticsDto
{
    /// <summary>
    ///     ID мероприятия.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    ///     Максимальное количество участников.
    /// </summary>
    public int? MaxParticipantsCount { get; init; }

    /// <summary>
    ///     Количество участников мероприятия.
    /// </summary>
    public int? ParticipantsCount { get; init; }

    /// <summary>
    ///     Просмотры по дням.
    /// </summary>
    public List<ViewsDto> Views { get; init; } = [];

    /// <summary>
    ///     Общее количество просмотров.
    /// </summary>
    public long ViewsCount { get; init; }
}