using Ardalis.Specification;
using Events.Domain.Aggregates.Users;

namespace Events.Application.Services.Features.Users.Specifications;

public sealed class UserByIdSpec : Specification<User>
{
    public UserByIdSpec(Guid userId)
    {
        Query.Where(u => u.Id == userId);
    }

    public new UserByIdSpec AsNoTracking()
    {
        Query.AsNoTracking();
        return this;
    }
}