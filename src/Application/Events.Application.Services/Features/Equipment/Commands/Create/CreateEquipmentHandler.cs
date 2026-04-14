using Events.Application.Services.Features.Places.Specifications;
using Events.Application.Services.Shared;
using Events.Domain.Aggregates.Equipment;
using Events.Domain.Aggregates.Equipment.Errors;
using Events.Domain.Aggregates.Equipment.Factories;
using Events.Domain.Aggregates.Locations;
using Events.Domain.Aggregates.Locations.Errors;
using Events.Domain.Exceptions;
using MediatR;

namespace Events.Application.Services.Features.Equipment.Commands.Create;

public sealed class CreateEquipmentHandler(
    IRepository<EquipmentItem> equipmentRepository,
    IRepository<EquipmentType> equipmentTypeRepository,
    IRepository<Place> placeRepository)
    : IRequestHandler<CreateEquipmentCommand, int>
{
    public async Task<int> Handle(CreateEquipmentCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;

        var type = await equipmentTypeRepository.GetByIdAsync(dto.EquipmentTypeId, cancellationToken);

        if (type == null)
            throw new NotFoundException(EquipmentErrorMessages.Type.NotFoundById(dto.EquipmentTypeId));

        if (dto.PlaceId.HasValue)
        {
            var placeByIdSpec = new PlaceByIdSpec(dto.PlaceId.Value);
            var placeExists = await placeRepository.AnyAsync(placeByIdSpec, cancellationToken);

            if (!placeExists)
                throw new NotFoundException(PlaceErrorMessages.NotFoundById(dto.PlaceId.Value));
        }

        var equipment = EquipmentFactory.Create(dto.Title, dto.InventoryNumber, type, dto.PlaceId);

        await equipmentRepository.AddAsync(equipment, cancellationToken);

        return equipment.Id;
    }
}