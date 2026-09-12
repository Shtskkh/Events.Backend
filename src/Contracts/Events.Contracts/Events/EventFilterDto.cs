using System.ComponentModel.DataAnnotations;
using Events.Contracts.Shared;

namespace Events.Contracts.Events;

/// <summary>
///     Форма фильтра мероприятий.
/// </summary>
public sealed record EventFilterDto : IPagination
{
    /// <summary>
    ///     Текст (необязательно).
    /// </summary>
    public string? Text { get; init; }

    /// <summary>
    ///     Дата и время начала (необязательно).
    /// </summary>
    public DateTimeOffset? StartDateTime { get; init; }

    /// <summary>
    ///     Дата и время окончания (необязательно).
    /// </summary>
    public DateTimeOffset? EndDateTime { get; init; }

    /// <summary>
    ///     ID типа мероприятия (необязательно).
    /// </summary>
    public int? TypeId { get; init; }

    /// <summary>
    ///     ID формата мероприятия (необязательно).
    /// </summary>
    public int? FormatId { get; init; }

    /// <summary>
    ///     ID создателя мероприятия (необязательно).
    /// </summary>
    public Guid? UserId { get; init; }

    /// <summary>
    ///     ID локации (необязательно).
    /// </summary>
    public int? LocationId { get; init; }

    /// <summary>
    ///     ID помещения (необязательно).
    /// </summary>
    public int? PlaceId { get; init; }

    /// <summary>
    ///     Дата и время начала периода создания (необязательно).
    /// </summary>
    public DateTimeOffset? CreatedAfter { get; init; }

    /// <summary>
    ///     Дата и время начала периода создания (необязательно).
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