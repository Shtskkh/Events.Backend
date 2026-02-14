using System.ComponentModel.DataAnnotations;
using Events.Contracts.Shared;

namespace Events.Contracts.Features.Events.DTOs;

/// <summary>
///     Фильтр мероприятий.
/// </summary>
public class EventFilterDto : IPagination
{
    /// <summary>
    ///     Тип мероприятия.
    /// </summary>
    public int? EventTypeId { get; set; }

    /// <summary>
    ///     Формат мероприятия.
    /// </summary>
    public int? EventFormatId { get; set; }

    /// <summary>
    ///     Размер выборки.
    /// </summary>
    [Range(1, int.MaxValue)]
    public required int Size { get; set; }

    /// <summary>
    ///     Страница выборки.
    /// </summary>
    [Range(1, int.MaxValue)]
    public required int Page { get; set; }
}