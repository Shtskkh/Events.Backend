using Ardalis.Specification;
using Events.Contracts.Features.Events.DTOs;
using Events.Domain.Aggregates.EventAggregate;

namespace Events.Application.Services.Features.Events.Specifications;

/// <summary>
///     Спецификация фильтра мероприятий.
/// </summary>
public class EventFilterSpecification : Specification<Event>
{
    /// <summary>
    ///     Конструктор спецификации фильтра мероприятий.
    /// </summary>
    /// <param name="filter">DTO фильтра.</param>
    public EventFilterSpecification(EventFilterDto filter)
    {
        if (filter.EventTypeId != null)
            Query.Where(e => e.Type.Id == filter.EventTypeId);

        if (filter.EventFormatId != null)
            Query.Where(e => e.Format.Id == filter.EventFormatId);

        Query.AsNoTracking();
        Query.Skip(filter.Size * (filter.Page - 1));
        Query.Take(filter.Size);
    }
}