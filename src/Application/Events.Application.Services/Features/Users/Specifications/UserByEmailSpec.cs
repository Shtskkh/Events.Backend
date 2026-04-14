using Ardalis.Specification;
using Events.Domain.Aggregates.Users;

namespace Events.Application.Services.Features.Users.Specifications;

public sealed class UserByEmailSpec : Specification<User>
{
    public UserByEmailSpec(string email)
    {
        Query.Where(e => e.Email.Value == email);
    }
}