using Events.Contracts.Equipment.EquipmentTypes;
using MediatR;

namespace Events.Application.Services.Features.Equipment.Queries.GetTypes;

/// <inheritdoc />
public sealed record GetEquipmentTypesQuery : IRequest<IReadOnlyCollection<EquipmentTypeDto>>;