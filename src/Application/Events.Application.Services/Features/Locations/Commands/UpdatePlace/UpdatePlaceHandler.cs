using Events.Application.Services.Features.Locations.Repositories;
using MediatR;

namespace Events.Application.Services.Features.Locations.Commands.UpdatePlace;

/// <inheritdoc />
public class UpdatePlaceHandler(ILocationRepository locationRepository, IPlaceTypeRepository placeTypeRepository)
    : IRequestHandler<UpdatePlaceCommand>
{
    /// <inheritdoc />
    public async Task Handle(UpdatePlaceCommand request, CancellationToken cancellationToken)
    {
        var dto = request.UpdateDto;
        const bool includePlaces = true;
        var location = await locationRepository.GetByIdAsync(request.LocationId, includePlaces, cancellationToken);
        var place = location.FindPlace(request.PlaceId);

        if (dto.Capacity.HasValue)
            place.ChangeCapacity(dto.Capacity.Value);

        if (dto.Type != null)
        {
            var type = await placeTypeRepository.GetByIdAsync(dto.Type.Value, cancellationToken);
            place.ChangeType(type);
        }

        if (dto.Title != null)
            place.ChangeTitle(dto.Title);

        await locationRepository.UpdateAsync(location, cancellationToken);
    }
}