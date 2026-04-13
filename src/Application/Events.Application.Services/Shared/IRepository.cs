using Ardalis.Specification;

namespace Events.Application.Services.Shared;

public interface IRepository<T> : IRepositoryBase<T> where T : class;