using System.ComponentModel.DataAnnotations;
using Events.Contracts.Shared;

namespace Events.Contracts.Events;

/// <summary>
///     Фильтр мероприятий.
/// </summary>
public record EventFilterDto : IPagination
{
    /// <summary>
    ///     Текст.
    /// </summary>
    public string? Text { get; init; }

    /// <summary>
    ///     Дата начала.
    /// </summary>
    public DateTimeOffset? StartDateTime { get; init; }

    /// <summary>
    ///     Дата окончания.
    /// </summary>
    public DateTimeOffset? EndDateTime { get; init; }

    /// <summary>
    ///     Тип мероприятия.
    /// </summary>
    public int? TypeId { get; init; }

    /// <summary>
    ///     Формат мероприятия.
    /// </summary>
    public int? FormatId { get; init; }

    /// <summary>
    ///     ID создателя мероприятия.
    /// </summary>
    public Guid? UserId { get; init; }

    /// <summary>
    ///     ID помещения.
    /// </summary>
    public int? PlaceId { get; init; }

    /// <summary>
    ///     Дата создания после.
    /// </summary>
    public DateTimeOffset? CreatedAfter { get; init; }

    /// <summary>
    ///     Дата создания до.
    /// </summary>
    public DateTimeOffset? CreatedBefore { get; init; }

    /// <summary>
    ///     Размер выборки.
    /// </summary>
    [Range(1, 30)]
    public required int Size { get; init; }

    /// <summary>
    ///     Страница выборки.
    /// </summary>
    [Range(1, int.MaxValue)]
    public required int Page { get; init; }
}