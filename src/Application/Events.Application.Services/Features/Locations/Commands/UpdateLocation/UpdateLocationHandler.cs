using Events.Application.Services.Features.Locations.Repositories;
using MediatR;

namespace Events.Application.Services.Features.Locations.Commands.UpdateLocation;

/// <inheritdoc />
public class UpdateLocationHandler(ILocationRepository locationRepository) : IRequestHandler<UpdateLocationCommand>
{
    /// <inheritdoc />
    public async Task Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
    {
        var dto = request.UpdateDto;
        const bool includePlaces = false;
        var location = await locationRepository.GetByIdAsync(request.LocationId, includePlaces, cancellationToken);

        if (dto.Title != null)
            location.ChangeTitle(dto.Title);

        if (dto.Address != null)
            location.ChangeAddress(dto.Address);

        await locationRepository.UpdateAsync(location, cancellationToken);
    }
}