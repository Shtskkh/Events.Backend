using Events.Application.Services.Shared;
using MediatR;

namespace Events.Application.Services.Features.Equipment.Commands.Delete;

public sealed class DeleteEquipmentHandler(
    IRepository<Domain.Aggregates.EquipmentAggregate.Equipment> equipmentRepository)
    : IRequestHandler<DeleteEquipmentCommand>
{
    public async Task Handle(DeleteEquipmentCommand request, CancellationToken cancellationToken)
    {
        var equipment = await equipmentRepository.GetByIdAsync(request.Id, cancellationToken);
        await equipmentRepository.DeleteAsync(equipment, cancellationToken);
    }
}