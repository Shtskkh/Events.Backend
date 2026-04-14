using Ardalis.Specification;

namespace Events.Application.Services.Shared;

public interface IRepository<T> : IRepositoryBase<T>
    where T : class
{
    Task<List<TResult>> QueryAsync<TResult>(
        QueryObject<T, TResult> query,
        CancellationToken cancellationToken = default);
}