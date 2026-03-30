using Events.Contracts.Features.EquipmentTypes;
using MediatR;

namespace Events.Application.Services.Features.Equipment.Queries.GetTypes;

/// <inheritdoc />
public record GetEquipmentTypesQuery : IRequest<IReadOnlyCollection<EquipmentTypeDto>>;