using MediatR;

namespace Events.Application.Services.Features.Equipment.Commands.Delete;

public record DeleteEquipmentCommand(int Id) : IRequest;