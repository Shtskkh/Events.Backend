using Events.Application.Services.Features.Locations.Specifications;
using Events.Application.Services.Shared;
using Events.Domain.Aggregates.Locations;
using Events.Domain.Aggregates.Locations.Errors;
using Events.Domain.Exceptions;
using MediatR;

namespace Events.Application.Services.Features.Places.Commands.Delete;

public sealed class DeletePlaceHandler(IRepository<Location> locationRepository) : IRequestHandler<DeletePlaceCommand>
{
    public async Task Handle(DeletePlaceCommand request, CancellationToken cancellationToken)
    {
        var locationByIdSpec = new LocationByIdSpec(request.LocationId).IncludePlaces();
        var location = await locationRepository.FirstOrDefaultAsync(locationByIdSpec, cancellationToken);

        if (location == null)
            throw new NotFoundException(LocationErrorMessages.NotFoundById(request.LocationId));

        location.RemovePlace(request.PlaceId);

        await locationRepository.UpdateAsync(location, cancellationToken);
    }
}