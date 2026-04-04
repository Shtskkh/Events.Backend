using MediatR;

namespace Events.Application.Services.Features.Locations.Commands.Delete;

/// <inheritdoc />
public sealed record DeleteLocationCommand(int LocationId) : IRequest;