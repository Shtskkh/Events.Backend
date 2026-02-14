using System.ComponentModel.DataAnnotations;
using Events.Contracts.Shared;

namespace Events.Contracts.Features.Events.DTOs;

/// <summary>
///     Фильтр мероприятий.
/// </summary>
public class EventFilterDto : IPagination
{
    /// <summary>
    ///     Текст.
    /// </summary>
    public string? Text { get; set; }

    /// <summary>
    ///     Тип мероприятия.
    /// </summary>
    public int? TypeId { get; set; }

    /// <summary>
    ///     Формат мероприятия.
    /// </summary>
    public int? FormatId { get; set; }

    /// <summary>
    ///     Размер выборки.
    /// </summary>
    [Range(1, 30)]
    public required int Size { get; set; }

    /// <summary>
    ///     Страница выборки.
    /// </summary>
    [Range(1, int.MaxValue)]
    public required int Page { get; set; }
}