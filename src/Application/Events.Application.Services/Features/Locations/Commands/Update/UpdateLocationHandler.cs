using Events.Application.Services.Features.Locations.Repositories;
using Events.Application.Services.Features.Locations.Specifications;
using MediatR;

namespace Events.Application.Services.Features.Locations.Commands.Update;

/// <inheritdoc />
public class UpdateLocationHandler(ILocationRepository locationRepository) : IRequestHandler<UpdateLocationCommand>
{
    /// <inheritdoc />
    public async Task Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
    {
        var spec = new LocationByIdSpec(request.LocationId);
        var location = await locationRepository.GetAsync(spec, cancellationToken);

        var dto = request.UpdateDto;

        if (dto.Title != null)
            location.ChangeTitle(dto.Title);

        if (dto.Address != null)
            location.ChangeAddress(dto.Address);

        await locationRepository.UpdateAsync(location, cancellationToken);
    }
}