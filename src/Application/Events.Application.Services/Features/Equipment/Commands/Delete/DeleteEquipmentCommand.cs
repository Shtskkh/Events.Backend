using MediatR;

namespace Events.Application.Services.Features.Equipment.Commands.Delete;

public sealed record DeleteEquipmentCommand(int Id) : IRequest;