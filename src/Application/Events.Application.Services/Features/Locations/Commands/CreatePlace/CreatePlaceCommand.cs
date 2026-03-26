using Events.Contracts.Features.Locations.Places;
using MediatR;

namespace Events.Application.Services.Features.Locations.Commands.CreatePlace;

/// <inheritdoc />
public record CreatePlaceCommand(int LocationId, CreatePlaceDto Dto) : IRequest<int>;