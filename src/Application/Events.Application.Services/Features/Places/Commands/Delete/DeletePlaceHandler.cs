using Events.Application.Services.Features.Locations.Specifications;
using Events.Application.Services.Shared;
using Events.Domain.Aggregates.Locations;
using MediatR;

namespace Events.Application.Services.Features.Places.Commands.Delete;

public sealed class DeletePlaceHandler(IRepository<Location> locationRepository) : IRequestHandler<DeletePlaceCommand>
{
    public async Task Handle(DeletePlaceCommand request, CancellationToken cancellationToken)
    {
        var spec = new LocationSpec().WithId(request.LocationId).IncludePlaces();
        var location = await locationRepository.FirstOrDefaultAsync(spec, cancellationToken);

        location.RemovePlace(request.PlaceId);

        await locationRepository.UpdateAsync(location, cancellationToken);
    }
}