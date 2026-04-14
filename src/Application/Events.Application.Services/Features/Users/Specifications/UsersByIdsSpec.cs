using Ardalis.Specification;
using Events.Domain.Aggregates.Users;

namespace Events.Application.Services.Features.Users.Specifications;

public sealed class UsersByIdsSpec : Specification<User>
{
    public UsersByIdsSpec(IEnumerable<Guid> userIds)
    {
        Query.Where(u => userIds.Contains(u.Id));
    }

    public new UsersByIdsSpec AsNoTracking()
    {
        Query.AsNoTracking();
        return this;
    }
}