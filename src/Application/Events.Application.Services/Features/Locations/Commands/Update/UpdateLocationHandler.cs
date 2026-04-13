using Events.Application.Services.Shared;
using Events.Domain.Aggregates.Locations;
using MediatR;

namespace Events.Application.Services.Features.Locations.Commands.Update;

public sealed class UpdateLocationHandler(IRepository<Location> locationRepository)
    : IRequestHandler<UpdateLocationCommand>
{
    public async Task Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
    {
        var location = await locationRepository.GetByIdAsync(request.LocationId, cancellationToken);

        var dto = request.UpdateDto;

        if (dto.Title != null)
            location.ChangeTitle(dto.Title);

        if (dto.Address != null)
            location.ChangeAddress(dto.Address);

        await locationRepository.UpdateAsync(location, cancellationToken);
    }
}