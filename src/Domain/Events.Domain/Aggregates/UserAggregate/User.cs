using Events.Domain.Interfaces;
using Events.Domain.Shared;

namespace Events.Domain.Aggregates.UserAggregate;

public class User : Entity<Guid>, IAggregateRoot
{
    public User() : base(Guid.NewGuid())
    {
    }
}