using AutoMapper;
using Events.Application.Services.Features.Equipment.Repositories;
using Events.Application.Services.Features.Equipment.Specifications;
using Events.Contracts.Equipment;
using MediatR;

namespace Events.Application.Services.Features.Equipment.Queries.GetByFilter;

public class GetEquipmentByFilterHandler(IEquipmentRepository equipmentRepository, IMapper mapper)
    : IRequestHandler<GetEquipmentByFilterQuery,
        IReadOnlyCollection<EquipmentDto>>
{
    public async Task<IReadOnlyCollection<EquipmentDto>> Handle(
        GetEquipmentByFilterQuery request, CancellationToken cancellationToken)
    {
        var spec = new EquipmentFilterSpec(request.Filter).AsNoTracking();
        var equipment = await equipmentRepository.GetByFilterAsync(spec, cancellationToken);

        return mapper.Map<IReadOnlyCollection<EquipmentDto>>(equipment);
    }
}