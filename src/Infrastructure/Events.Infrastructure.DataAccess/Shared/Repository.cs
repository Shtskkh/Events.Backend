using Ardalis.Specification.EntityFrameworkCore;
using Events.Application.Services.Shared;
using Microsoft.EntityFrameworkCore;

namespace Events.Infrastructure.DataAccess.Shared;

public class Repository<T>(DbContext dbContext) : RepositoryBase<T>(dbContext), IRepository<T>
    where T : class;