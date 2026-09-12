using Events.Contracts.Equipment;
using MediatR;

namespace Events.Application.Services.Features.Equipment.Commands.Create;

public sealed record CreateEquipmentCommand(CreateEquipmentDto Dto) : IRequest<int>;