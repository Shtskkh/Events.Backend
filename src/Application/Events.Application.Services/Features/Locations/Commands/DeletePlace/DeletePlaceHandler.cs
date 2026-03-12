using Events.Application.Services.Features.Locations.Repositories;
using MediatR;

namespace Events.Application.Services.Features.Locations.Commands.DeletePlace;

/// <inheritdoc />
public class DeletePlaceHandler(ILocationRepository locationRepository) : IRequestHandler<DeletePlaceCommand>
{
    /// <inheritdoc />
    public async Task Handle(DeletePlaceCommand request, CancellationToken cancellationToken)
    {
        const bool includePlaces = true;
        var location = await locationRepository.GetByIdAsync(request.LocationId, includePlaces, cancellationToken);

        location.RemovePlace(request.PlaceId);

        await locationRepository.UpdateAsync(location, cancellationToken);
    }
}