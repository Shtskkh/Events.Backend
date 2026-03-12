using Ardalis.Specification;
using Events.Domain.Aggregates.UserAggregate;

namespace Events.Application.Services.Features.Events.Specifications;

/// <summary>
///     Спецификация получения участников мероприятия.
/// </summary>
public class EventParticipantsSpecification : Specification<User>
{
    /// <summary>
    ///     Конструктор.
    /// </summary>
    /// <param name="participantIds">Идентификаторы участников.</param>
    public EventParticipantsSpecification(IEnumerable<Guid> participantIds)
    {
        Query.Where(u => participantIds.Contains(u.Id));
    }
}