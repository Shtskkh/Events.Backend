using Events.Application.Services.Features.Equipment.Repositories;
using Events.Domain.Aggregates.EquipmentAggregate;
using Events.Domain.Exceptions;
using Events.Infrastructure.DataAccess.Repositories;
using Events.Infrastructure.DataAccess.Shared;
using Microsoft.EntityFrameworkCore;

namespace Events.Infrastructure.DataAccess.Context.Equipment.Repositories;

/// <inheritdoc />
public class EquipmentTypeRepository(IRepository<EquipmentType, int, EventsDbContext> repository)
    : IEquipmentTypeRepository
{
    /// <inheritdoc />
    public async Task<IReadOnlyCollection<EquipmentType>> GetAllAsync(CancellationToken cancellationToken)
    {
        var types = await repository.GetAllAsync()
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        if (types.Count == 0)
            throw new NotFoundException(DataAccessErrorMessages.Equipment.Types.NotFoundAny);

        return types;
    }

    /// <inheritdoc />
    public async Task<EquipmentType> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var type = await repository.GetByIdAsync(id, cancellationToken);

        if (type == null)
            throw new NotFoundException(DataAccessErrorMessages.Equipment.Types.NotFound);

        return type;
    }

    /// <inheritdoc />
    public async Task AddAsync(EquipmentType equipmentType, CancellationToken cancellationToken)
    {
        await repository.AddAsync(equipmentType, cancellationToken);
    }

    /// <inheritdoc />
    public async Task UpdateAsync(EquipmentType equipmentType, CancellationToken cancellationToken)
    {
        await repository.UpdateAsync(equipmentType, cancellationToken);
    }

    /// <inheritdoc />
    public async Task DeleteAsync(EquipmentType equipmentType, CancellationToken cancellationToken)
    {
        await repository.DeleteAsync(equipmentType, cancellationToken);
    }
}