using Ardalis.Specification;

namespace Events.Application.Services.Shared;

public interface IAnalyticsRepository<T> : IRepositoryBase<T>
    where T : class;