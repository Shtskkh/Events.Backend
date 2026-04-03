using Events.Contracts.Locations;
using MediatR;

namespace Events.Application.Services.Features.Locations.Queries.GetLocationById;

/// <inheritdoc />
public record GetLocationByIdQuery(int Id) : IRequest<LocationDto>;