using Events.Contracts.Places;
using MediatR;

namespace Events.Application.Services.Features.Places.Commands.Create;

/// <inheritdoc />
public sealed record CreatePlaceCommand(int LocationId, CreatePlaceDto Dto) : IRequest<int>;