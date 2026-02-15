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
        if (filter.Text != null)
        {
            var words = filter.Text
                .Split([' ', ',', '.', '\t', '\n'], StringSplitOptions.RemoveEmptyEntries)
                .Distinct();

            foreach (var word in words)
                Query.Search(e => e.Title.Value, '%' + word + '%')
                    .Search(e => e.Announcement.Value, '%' + word + '%')
                    .Search(e => e.Description.Value, '%' + word + '%');
        }

        if (filter.StartDateTime != null)
            Query.Where(e => e.StartDateTime >= filter.StartDateTime);

        if (filter.EndDateTime != null)
            Query.Where(e => e.EndDateTime <= filter.EndDateTime);

        if (filter.TypeId != null)
            Query.Where(e => e.Type.Id == filter.TypeId);

        if (filter.FormatId != null)
            Query.Where(e => e.Format.Id == filter.FormatId);

        Query.OrderByDescending(e => e.CreatedAt);
        Query.AsNoTracking();
        Query.Skip(filter.Size * (filter.Page - 1));
        Query.Take(filter.Size);
    }
}