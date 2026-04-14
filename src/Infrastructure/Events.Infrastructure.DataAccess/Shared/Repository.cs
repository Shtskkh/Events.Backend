using Ardalis.Specification.EntityFrameworkCore;
using Events.Application.Services.Shared;
using Microsoft.EntityFrameworkCore;

namespace Events.Infrastructure.DataAccess.Shared;

public class Repository<T>(EventsDbContext dbContext) : RepositoryBase<T>(dbContext), IRepository<T>
    where T : class
{
    public async Task<List<TResult>> QueryAsync<TResult>(QueryObject<T, TResult> query,
        CancellationToken cancellationToken = default)
    {
        return await query.Build(DbContext.Set<T>().AsNoTracking()).ToListAsync(cancellationToken);
    }
}