using Ardalis.Specification;
using Events.Domain.Aggregates.Users;

namespace Events.Application.Services.Features.Users.Specifications;

/// <summary>
///     Спецификация пользователя.
/// </summary>
public class UserSpec : Specification<User>
{
    public UserSpec WithId(Guid id)
    {
        Query.Where(x => x.Id == id);
        return this;
    }

    public UserSpec WithIdList(IEnumerable<Guid> ids)
    {
        Query.Where(x => ids.Contains(x.Id));
        return this;
    }

    public UserSpec WithEmail(string email)
    {
        Query.Where(e => e.Email.Value == email);
        return this;
    }

    public new UserSpec AsNoTracking()
    {
        Query.AsNoTracking();
        return this;
    }
}