using AutoMapper;
using Events.Application.Services.Features.Locations.Specifications;
using Events.Application.Services.Shared;
using Events.Contracts.Locations;
using Events.Domain.Aggregates.Locations;
using Events.Domain.Aggregates.Locations.Errors;
using Events.Domain.Exceptions;
using MediatR;

namespace Events.Application.Services.Features.Locations.Queries.GetById;

public sealed class GetLocationByIdHandler(IRepository<Location> locationRepository, IMapper mapper)
    : IRequestHandler<GetLocationByIdQuery, LocationDto>
{
    public async Task<LocationDto> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
    {
        var spec = new LocationByIdSpec(request.Id).IncludePhotos().AsNoTracking();
        var location = await locationRepository.FirstOrDefaultAsync(spec, cancellationToken);

        if (location == null)
            throw new NotFoundException(LocationErrorMessages.NotFoundById(request.Id));

        return mapper.Map<LocationDto>(location);
    }
}