using Events.Application.Services.Shared;
using Events.Domain.Aggregates.Locations;
using Events.Domain.Aggregates.Locations.Errors;
using Events.Domain.Exceptions;
using MediatR;

namespace Events.Application.Services.Features.Locations.Commands.Delete;

public sealed class DeleteLocationHandler(IRepository<Location> locationRepository)
    : IRequestHandler<DeleteLocationCommand>
{
    public async Task Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
    {
        var location = await locationRepository.GetByIdAsync(request.LocationId, cancellationToken);

        if (location == null)
            throw new NotFoundException(LocationErrors.NotFoundById(request.LocationId));

        await locationRepository.DeleteAsync(location, cancellationToken);
    }
}