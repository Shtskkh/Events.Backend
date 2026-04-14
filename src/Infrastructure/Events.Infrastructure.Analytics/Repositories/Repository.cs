using Ardalis.Specification.EntityFrameworkCore;
using Events.Application.Services.Shared;
using Microsoft.EntityFrameworkCore;

namespace Events.Infrastructure.Analytics.Repositories;

public class Repository<T> : RepositoryBase<T>, IRepository<T>
    where T : class
{
    public Repository(AnalyticsDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<TResult>> QueryAsync<TResult>(QueryObject<T, TResult> query,
        CancellationToken cancellationToken = default)
    {
        return await query.Build(DbContext.Set<T>().AsNoTracking()).ToListAsync(cancellationToken);
    }
}