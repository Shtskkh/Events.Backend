using Events.Application.Services.Features.Locations.Repositories;
using Events.Application.Services.Features.Locations.Specifications;
using MediatR;

namespace Events.Application.Services.Features.Places.Commands.Delete;

/// <inheritdoc />
public sealed class DeletePlaceHandler(ILocationRepository locationRepository) : IRequestHandler<DeletePlaceCommand>
{
    /// <inheritdoc />
    public async Task Handle(DeletePlaceCommand request, CancellationToken cancellationToken)
    {
        var spec = new LocationSpec().WithId(request.LocationId).IncludePlaces();
        var location = await locationRepository.GetAsync(spec, cancellationToken);

        location.RemovePlace(request.PlaceId);

        await locationRepository.UpdateAsync(location, cancellationToken);
    }
}