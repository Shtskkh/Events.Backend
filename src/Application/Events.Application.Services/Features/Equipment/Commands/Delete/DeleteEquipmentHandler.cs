using Events.Application.Services.Shared;
using Events.Domain.Aggregates.Equipment;
using Events.Domain.Aggregates.Equipment.Errors;
using Events.Domain.Exceptions;
using MediatR;

namespace Events.Application.Services.Features.Equipment.Commands.Delete;

public sealed class DeleteEquipmentHandler(
    IRepository<EquipmentItem> equipmentRepository)
    : IRequestHandler<DeleteEquipmentCommand>
{
    public async Task Handle(DeleteEquipmentCommand request, CancellationToken cancellationToken)
    {
        var equipment = await equipmentRepository.GetByIdAsync(request.EquipmentItemId, cancellationToken);

        if (equipment == null)
            throw new NotFoundException(EquipmentErrorMessages.NotFoundById(request.EquipmentItemId));

        await equipmentRepository.DeleteAsync(equipment, cancellationToken);
    }
}