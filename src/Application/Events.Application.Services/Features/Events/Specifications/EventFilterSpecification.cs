using Ardalis.Specification;
using Events.Contracts.Features.Events.DTOs;
using Events.Domain.Aggregates.EventAggregate;

namespace Events.Application.Services.Features.Events.Specifications;

public class EventFilterSpecification : Specification<Event>
{
    public EventFilterSpecification(EventFilterDto filter)
    {
        Query.AsNoTracking();
        Query.Skip(filter.Size * (filter.Page - 1));
        Query.Take(filter.Size);
    }
}