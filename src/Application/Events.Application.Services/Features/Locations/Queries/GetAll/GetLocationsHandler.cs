using AutoMapper;
using Events.Application.Services.Shared;
using Events.Contracts.Locations;
using Events.Domain.Aggregates.Locations;
using Events.Domain.Aggregates.Locations.Errors;
using Events.Domain.Exceptions;
using MediatR;

namespace Events.Application.Services.Features.Locations.Queries.GetAll;

public sealed class GetLocationsHandler(IRepository<Location> locationRepository, IMapper mapper)
    : IRequestHandler<GetLocationsQuery, IReadOnlyCollection<ShortLocationDto>>
{
    public async Task<IReadOnlyCollection<ShortLocationDto>> Handle(GetLocationsQuery request,
        CancellationToken cancellationToken)
    {
        var locations = await locationRepository.ListAsync(cancellationToken);

        if (locations.Count == 0)
            throw new NotFoundException(LocationErrorMessages.NotFoundAny);

        return mapper.Map<IReadOnlyCollection<ShortLocationDto>>(locations);
    }
}