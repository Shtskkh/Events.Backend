using Ardalis.Specification.EntityFrameworkCore;
using Events.Application.Services.Shared;

namespace Events.Infrastructure.Analytics.Repositories;

public class AnalyticsRepository<T> : RepositoryBase<T>, IAnalyticsRepository<T>
    where T : class
{
    public AnalyticsRepository(AnalyticsDbContext dbContext) : base(dbContext)
    {
    }
}