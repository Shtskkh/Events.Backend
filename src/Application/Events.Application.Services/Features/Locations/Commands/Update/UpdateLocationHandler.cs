using Events.Application.Services.Shared;
using Events.Domain.Aggregates.Locations;
using Events.Domain.Aggregates.Locations.Errors;
using Events.Domain.Exceptions;
using MediatR;

namespace Events.Application.Services.Features.Locations.Commands.Update;

public sealed class UpdateLocationHandler(IRepository<Location> locationRepository)
    : IRequestHandler<UpdateLocationCommand>
{
    public async Task Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
    {
        var location = await locationRepository.GetByIdAsync(request.LocationId, cancellationToken);

        if (location == null)
            throw new NotFoundException(LocationErrors.NotFoundById(request.LocationId));

        var dto = request.UpdateDto;

        if (!string.IsNullOrWhiteSpace(dto.Title))
            location.ChangeTitle(dto.Title);

        if (!string.IsNullOrWhiteSpace(dto.Address))
            location.ChangeAddress(dto.Address);

        await locationRepository.UpdateAsync(location, cancellationToken);
    }
}