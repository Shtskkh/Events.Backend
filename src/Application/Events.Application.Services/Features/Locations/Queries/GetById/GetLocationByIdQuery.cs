using Events.Contracts.Locations;
using MediatR;

namespace Events.Application.Services.Features.Locations.Queries.GetById;

/// <inheritdoc />
public record GetLocationByIdQuery(int Id) : IRequest<LocationDto>;