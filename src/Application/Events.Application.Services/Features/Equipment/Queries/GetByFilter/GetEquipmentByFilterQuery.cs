using Events.Contracts.Equipment;
using MediatR;

namespace Events.Application.Services.Features.Equipment.Queries.GetByFilter;

public record GetEquipmentByFilterQuery(EquipmentFilterDto Filter)
    : IRequest<IReadOnlyCollection<EquipmentDto>>;