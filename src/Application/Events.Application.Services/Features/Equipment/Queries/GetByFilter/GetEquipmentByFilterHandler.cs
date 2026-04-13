using AutoMapper;
using Events.Application.Services.Features.Equipment.Specifications;
using Events.Application.Services.Shared;
using Events.Contracts.Equipment;
using MediatR;

namespace Events.Application.Services.Features.Equipment.Queries.GetByFilter;

public sealed class GetEquipmentByFilterHandler(
    IRepository<Domain.Aggregates.EquipmentAggregate.Equipment> equipmentRepository,
    IMapper mapper)
    : IRequestHandler<GetEquipmentByFilterQuery,
        IReadOnlyCollection<EquipmentDto>>
{
    public async Task<IReadOnlyCollection<EquipmentDto>> Handle(
        GetEquipmentByFilterQuery request, CancellationToken cancellationToken)
    {
        var spec = new EquipmentFilterSpec(request.Filter).AsNoTracking();
        var equipment = await equipmentRepository.ListAsync(spec, cancellationToken);

        return mapper.Map<IReadOnlyCollection<EquipmentDto>>(equipment);
    }
}