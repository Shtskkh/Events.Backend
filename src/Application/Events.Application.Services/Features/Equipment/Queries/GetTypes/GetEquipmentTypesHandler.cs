using AutoMapper;
using Events.Application.Services.Shared;
using Events.Contracts.Equipment.EquipmentTypes;
using Events.Domain.Aggregates.Equipment;
using Events.Domain.Aggregates.Equipment.Errors;
using Events.Domain.Exceptions;
using MediatR;

namespace Events.Application.Services.Features.Equipment.Queries.GetTypes;

public sealed class GetEquipmentTypesHandler(IRepository<EquipmentType> equipmentTypeRepository, IMapper mapper)
    : IRequestHandler<GetEquipmentTypesQuery, IReadOnlyCollection<EquipmentTypeDto>>
{
    public async Task<IReadOnlyCollection<EquipmentTypeDto>> Handle(GetEquipmentTypesQuery request,
        CancellationToken cancellationToken)
    {
        var types = await equipmentTypeRepository.ListAsync(cancellationToken);

        if (types.Count == 0)
            throw new NotFoundException(EquipmentErrorMessages.Type.NotFoundAny);

        return mapper.Map<IReadOnlyCollection<EquipmentTypeDto>>(types);
    }
}