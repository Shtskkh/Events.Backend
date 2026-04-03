using AutoMapper;
using Events.Application.Services.Features.Equipment.Repositories;
using Events.Contracts.Equipment.EquipmentTypes;
using MediatR;

namespace Events.Application.Services.Features.Equipment.Queries.GetTypes;

/// <inheritdoc />
public class GetEquipmentTypesHandler(IEquipmentTypeRepository repository, IMapper mapper)
    : IRequestHandler<GetEquipmentTypesQuery, IReadOnlyCollection<EquipmentTypeDto>>
{
    /// <inheritdoc />
    public async Task<IReadOnlyCollection<EquipmentTypeDto>> Handle(GetEquipmentTypesQuery request,
        CancellationToken cancellationToken)
    {
        var types = await repository.GetAllAsync(cancellationToken);

        return mapper.Map<IReadOnlyCollection<EquipmentTypeDto>>(types);
    }
}