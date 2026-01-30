using Events.Contracts.Shared;

namespace Events.Contracts.Features.Events.DTOs;

/// <summary>
///     Фильтр мероприятий.
/// </summary>
public class EventFilterDto : IPagination
{
    /// <inheritdoc />
    public int Size { get; set; }

    /// <inheritdoc />
    public int Page { get; set; }
}