using Events.Application.Services.Features.Equipment.Repositories;
using Events.Application.Services.Features.Equipment.Specifications;
using MediatR;

namespace Events.Application.Services.Features.Equipment.Commands.Delete;

public sealed class DeleteEquipmentHandler(IEquipmentRepository equipmentRepository)
    : IRequestHandler<DeleteEquipmentCommand>
{
    public async Task Handle(DeleteEquipmentCommand request, CancellationToken cancellationToken)
    {
        var spec = new EquipmentByIdSpec(request.Id);
        var equipment = await equipmentRepository.GetAsync(spec, cancellationToken);

        await equipmentRepository.DeleteAsync(equipment, cancellationToken);
    }
}