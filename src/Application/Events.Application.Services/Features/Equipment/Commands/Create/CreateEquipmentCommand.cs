using Events.Contracts.Features.Equipment;
using MediatR;

namespace Events.Application.Services.Features.Equipment.Commands.Create;

public record CreateEquipmentCommand(CreateEquipmentDto Dto) : IRequest<int>;