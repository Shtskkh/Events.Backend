using Events.Application.Services.Features.Places.Repositories;
using Events.Application.Services.Shared;
using Events.Domain.Aggregates.EquipmentAggregate;
using Events.Domain.Aggregates.EquipmentAggregate.Factories;
using MediatR;

namespace Events.Application.Services.Features.Equipment.Commands.Create;

public sealed class CreateEquipmentHandler(
    IRepository<Domain.Aggregates.EquipmentAggregate.Equipment> equipmentRepository,
    IRepository<EquipmentType> equipmentTypeRepository,
    IPlaceRepository placeRepository)
    : IRequestHandler<CreateEquipmentCommand, int>
{
    public async Task<int> Handle(CreateEquipmentCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;

        var type = await equipmentTypeRepository.GetByIdAsync(dto.EquipmentTypeId, cancellationToken);

        if (dto.PlaceId.HasValue)
            await placeRepository.GetById(dto.PlaceId.Value, cancellationToken);

        var equipment = EquipmentFactory.Create(dto.Title, dto.InventoryNumber, type, dto.PlaceId);

        await equipmentRepository.AddAsync(equipment, cancellationToken);

        return equipment.Id;
    }
}