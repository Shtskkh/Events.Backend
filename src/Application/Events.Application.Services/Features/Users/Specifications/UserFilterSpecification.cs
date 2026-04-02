using Ardalis.Specification;
using Events.Contracts.Features.Users;
using Events.Domain.Aggregates.UserAggregate;

namespace Events.Application.Services.Features.Users.Specifications;

/// <summary>
///     Спецификация фильтра пользователей.
/// </summary>
public class UserFilterSpecification : Specification<User>
{
    /// <summary>
    ///     Конструктор.
    /// </summary>
    /// <param name="filter">DTO фильтра.</param>
    public UserFilterSpecification(UserFilterDto filter)
    {
        Query.OrderByDescending(e => e.CreatedAt);
        Query.AsNoTracking();
        Query.Skip(filter.Size * (filter.Page - 1));
        Query.Take(filter.Size);
    }
}