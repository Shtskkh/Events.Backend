using Ardalis.Specification;
using Events.Contracts.Users;
using Events.Domain.Aggregates.Users;

namespace Events.Application.Services.Features.Users.Specifications;

/// <summary>
///     Спецификация фильтра пользователей.
/// </summary>
public class UserFilterSpec : Specification<User>
{
    /// <summary>
    ///     Конструктор.
    /// </summary>
    /// <param name="filter">DTO фильтра.</param>
    public UserFilterSpec(UserFilterDto filter)
    {
        Query.OrderByDescending(e => e.CreatedAt);
        Query.AsNoTracking();
        Query.Skip(filter.Size * (filter.Page - 1));
        Query.Take(filter.Size);
    }
}