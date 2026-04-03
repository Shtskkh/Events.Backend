using Events.Application.Services.Features.Locations.Repositories;
using Events.Application.Services.Features.Locations.Specifications;
using MediatR;

namespace Events.Application.Services.Features.Locations.Commands.DeleteLocation;

/// <inheritdoc />
public class DeleteLocationHandler(ILocationRepository locationRepository) : IRequestHandler<DeleteLocationCommand>
{
    /// <inheritdoc />
    public async Task Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
    {
        var spec = new LocationByIdSpec(request.LocationId);
        var location = await locationRepository.GetAsync(spec, cancellationToken);

        await locationRepository.DeleteAsync(location, cancellationToken);
    }
}