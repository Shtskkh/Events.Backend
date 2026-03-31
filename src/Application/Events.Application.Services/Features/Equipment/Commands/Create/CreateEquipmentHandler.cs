using Events.Application.Services.Features.Equipment.Repositories;
using Events.Application.Services.Features.Locations.Repositories;
using Events.Domain.Aggregates.EquipmentAggregate.Factories;
using MediatR;

namespace Events.Application.Services.Features.Equipment.Commands.Create;

/// <inheritdoc />
public class CreateEquipmentHandler(
    IEquipmentRepository equipmentRepository,
    IEquipmentTypeRepository equipmentTypeRepository,
    IPlaceRepository placeRepository)
    : IRequestHandler<CreateEquipmentCommand, int>
{
    /// <inheritdoc />
    public async Task<int> Handle(CreateEquipmentCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;

        var type = await equipmentTypeRepository.GetByIdAsync(dto.EquipmentTypeId, cancellationToken);

        if (dto.PlaceId.HasValue)
            await placeRepository.GetById(dto.PlaceId.Value, cancellationToken);

        var equipment = EquipmentFactory.Create(dto.Title, type, dto.PlaceId);
        await equipmentRepository.AddAsync(equipment, cancellationToken);

        return equipment.Id;
    }
}