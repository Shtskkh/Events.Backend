using Events.Contracts.Shared;

namespace Events.Contracts.Features.Events.DTOs;

/// <summary>
///     Фильтр мероприятий.
/// </summary>
public class EventFilterDto : IPagination
{
    /// <summary>
    ///     Размер выборки.
    /// </summary>
    public int Size { get; set; }

    /// <summary>
    ///     Страница выборки.
    /// </summary>
    public int Page { get; set; }
}