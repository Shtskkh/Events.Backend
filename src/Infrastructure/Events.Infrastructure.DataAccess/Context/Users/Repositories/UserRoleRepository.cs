using Events.Application.Services.Features.Users.Repositories;
using Events.Domain.Aggregates.UserAggregate;
using Events.Infrastructure.DataAccess.Exceptions;
using Events.Infrastructure.DataAccess.Repositories;
using Events.Infrastructure.DataAccess.Shared;

namespace Events.Infrastructure.DataAccess.Context.Users.Repositories;

/// <inheritdoc />
public class UserRoleRepository(IRepository<UserRole, int, EventsDbContext> repository) : IUserRoleRepository
{
    /// <inheritdoc />
    public async Task<UserRole> GetById(int id, CancellationToken cancellationToken)
    {
        var role = await repository.GetByIdAsync(id, cancellationToken);

        if (role == null)
            throw new NotFoundException(DataAccessErrorMessages.Users.Roles.NotFound);

        return role;
    }
}