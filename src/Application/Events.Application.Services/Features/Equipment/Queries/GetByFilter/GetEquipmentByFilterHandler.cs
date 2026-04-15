using AutoMapper;
using Events.Application.Services.Features.Equipment.Specifications;
using Events.Application.Services.Shared;
using Events.Contracts.Equipment;
using Events.Domain.Aggregates.Equipment;
using Events.Domain.Aggregates.Equipment.Errors;
using Events.Domain.Exceptions;
using MediatR;

namespace Events.Application.Services.Features.Equipment.Queries.GetByFilter;

public sealed class GetEquipmentByFilterHandler(
    IRepository<EquipmentItem> equipmentRepository,
    IMapper mapper)
    : IRequestHandler<GetEquipmentByFilterQuery,
        IReadOnlyCollection<EquipmentDto>>
{
    public async Task<IReadOnlyCollection<EquipmentDto>> Handle(
        GetEquipmentByFilterQuery request, CancellationToken cancellationToken)
    {
        var equipmentFilterSpec = new EquipmentFilterSpec(request.Filter);
        var equipment = await equipmentRepository.ListAsync(equipmentFilterSpec, cancellationToken);

        if (equipment.Count == 0)
            throw new NotFoundException(EquipmentErrors.NotFoundByFilter);

        return mapper.Map<IReadOnlyCollection<EquipmentDto>>(equipment);
    }
}