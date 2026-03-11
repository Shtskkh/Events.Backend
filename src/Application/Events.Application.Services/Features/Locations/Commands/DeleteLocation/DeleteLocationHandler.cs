using Events.Application.Services.Features.Locations.Repositories;
using MediatR;

namespace Events.Application.Services.Features.Locations.Commands.DeleteLocation;

/// <inheritdoc />
public class DeleteLocationHandler(ILocationRepository locationRepository) : IRequestHandler<DeleteLocationCommand>
{
    /// <inheritdoc />
    public async Task Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
    {
        const bool includePlaces = false;

        var location = await locationRepository.GetByIdAsync(request.LocationId, includePlaces, cancellationToken);

        await locationRepository.DeleteAsync(location, cancellationToken);
    }
}