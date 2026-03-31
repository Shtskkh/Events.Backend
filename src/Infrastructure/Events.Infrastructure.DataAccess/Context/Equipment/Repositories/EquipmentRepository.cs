using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Events.Application.Services.Features.Equipment.Repositories;
using Events.Domain.Exceptions;
using Events.Infrastructure.DataAccess.Repositories;
using Events.Infrastructure.DataAccess.Shared;
using Microsoft.EntityFrameworkCore;

namespace Events.Infrastructure.DataAccess.Context.Equipment.Repositories;

/// <inheritdoc />
public class EquipmentRepository(
    IRepository<Domain.Aggregates.EquipmentAggregate.Equipment, int, EventsDbContext> repository) : IEquipmentRepository
{
    /// <inheritdoc />
    public async Task<IReadOnlyCollection<Domain.Aggregates.EquipmentAggregate.Equipment>> GetByFilterAsync(
        Specification<Domain.Aggregates.EquipmentAggregate.Equipment> spec, CancellationToken cancellationToken)
    {
        var equipment = await repository.GetAllAsync()
            .WithSpecification(spec)
            .ToListAsync(cancellationToken);

        if (equipment.Count == 0)
            throw new NotFoundException(DataAccessErrorMessages.Equipment.NotFoundAny);

        return equipment;
    }

    /// <inheritdoc />
    public async Task<Domain.Aggregates.EquipmentAggregate.Equipment> GetAsync(
        Specification<Domain.Aggregates.EquipmentAggregate.Equipment> spec, CancellationToken cancellationToken)
    {
        var equipment = await repository.GetAllAsync()
            .WithSpecification(spec)
            .FirstOrDefaultAsync(cancellationToken);

        if (equipment == null)
            throw new NotFoundException(DataAccessErrorMessages.Equipment.NotFound);

        return equipment;
    }

    /// <inheritdoc />
    public async Task AddAsync(Domain.Aggregates.EquipmentAggregate.Equipment equipment,
        CancellationToken cancellationToken)
    {
        await repository.AddAsync(equipment, cancellationToken);
    }

    /// <inheritdoc />
    public async Task UpdateAsync(Domain.Aggregates.EquipmentAggregate.Equipment equipment,
        CancellationToken cancellationToken)
    {
        await repository.UpdateAsync(equipment, cancellationToken);
    }

    /// <inheritdoc />
    public async Task DeleteAsync(Domain.Aggregates.EquipmentAggregate.Equipment equipment,
        CancellationToken cancellationToken)
    {
        await repository.DeleteAsync(equipment, cancellationToken);
    }
}