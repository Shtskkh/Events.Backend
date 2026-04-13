using Events.Application.Services.Shared;
using Events.Domain.Aggregates.Equipment;
using MediatR;

namespace Events.Application.Services.Features.Equipment.Commands.Delete;

public sealed class DeleteEquipmentHandler(
    IRepository<EquipmentItem> equipmentRepository)
    : IRequestHandler<DeleteEquipmentCommand>
{
    public async Task Handle(DeleteEquipmentCommand request, CancellationToken cancellationToken)
    {
        var equipment = await equipmentRepository.GetByIdAsync(request.Id, cancellationToken);
        await equipmentRepository.DeleteAsync(equipment, cancellationToken);
    }
}