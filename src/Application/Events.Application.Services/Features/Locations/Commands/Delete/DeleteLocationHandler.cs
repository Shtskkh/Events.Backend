using Events.Application.Services.Shared;
using Events.Domain.Aggregates.LocationAggregate;
using MediatR;

namespace Events.Application.Services.Features.Locations.Commands.Delete;

public sealed class DeleteLocationHandler(IRepository<Location> locationRepository)
    : IRequestHandler<DeleteLocationCommand>
{
    public async Task Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
    {
        var location = await locationRepository.GetByIdAsync(request.LocationId, cancellationToken);

        await locationRepository.DeleteAsync(location, cancellationToken);
    }
}