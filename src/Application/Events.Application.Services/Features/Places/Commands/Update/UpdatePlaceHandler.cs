using Events.Application.Services.Shared;
using Events.Domain.Aggregates.Locations;
using Events.Domain.Aggregates.Locations.Errors;
using Events.Domain.Exceptions;
using MediatR;

namespace Events.Application.Services.Features.Places.Commands.Update;

public sealed class UpdatePlaceHandler(IRepository<Place> placeRepository, IRepository<PlaceType> placeTypeRepository)
    : IRequestHandler<UpdatePlaceCommand>
{
    public async Task Handle(UpdatePlaceCommand request, CancellationToken cancellationToken)
    {
        var place = await placeRepository.GetByIdAsync(request.PlaceId, cancellationToken);

        if (place == null)
            throw new NotFoundException(PlaceErrorMessages.NotFoundById(request.PlaceId));

        var dto = request.UpdateDto;

        if (dto.Capacity.HasValue)
            place.ChangeCapacity(dto.Capacity.Value);

        if (dto.Type.HasValue)
        {
            var type = await placeTypeRepository.GetByIdAsync(dto.Type.Value, cancellationToken);
            if (type == null)
                throw new NotFoundException(PlaceErrorMessages.NotFoundById(dto.Type.Value));

            place.ChangeType(type);
        }

        if (!string.IsNullOrWhiteSpace(dto.Title))
            place.ChangeTitle(dto.Title);

        await placeRepository.UpdateAsync(place, cancellationToken);
    }
}