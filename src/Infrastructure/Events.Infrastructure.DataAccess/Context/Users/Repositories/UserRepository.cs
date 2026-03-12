using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Events.Application.Services.Features.Users.Repositories;
using Events.Domain.Aggregates.UserAggregate;
using Events.Domain.Exceptions;
using Events.Infrastructure.DataAccess.Repositories;
using Events.Infrastructure.DataAccess.Shared;
using Microsoft.EntityFrameworkCore;

namespace Events.Infrastructure.DataAccess.Context.Users.Repositories;

/// <inheritdoc />
public class UserRepository(IRepository<User, Guid, EventsDbContext> repository) : IUserRepository
{
    /// <inheritdoc />
    public async Task<IReadOnlyCollection<User>> GetByFilterAsync(
        Specification<User> spec,
        CancellationToken cancellationToken
    )
    {
        var users = await repository.GetAllAsync()
            .WithSpecification(spec)
            .ToListAsync(cancellationToken);

        if (users.Count == 0)
            throw new NotFoundException(DataAccessErrorMessages.Users.NotFoundAny);

        return users.AsReadOnly();
    }

    /// <inheritdoc />
    public async Task<User> GetById(Guid id, CancellationToken cancellationToken)
    {
        var user = await repository.GetByIdAsync(id, cancellationToken);

        if (user == null)
            throw new NotFoundException(DataAccessErrorMessages.Users.NotFound);

        return user;
    }

    /// <inheritdoc />
    public async Task AddAsync(User user, CancellationToken cancellationToken)
    {
        await repository.AddAsync(user, cancellationToken);
    }

    /// <inheritdoc />
    public async Task DeleteAsync(User user, CancellationToken cancellationToken)
    {
        await repository.DeleteAsync(user, cancellationToken);
    }
}