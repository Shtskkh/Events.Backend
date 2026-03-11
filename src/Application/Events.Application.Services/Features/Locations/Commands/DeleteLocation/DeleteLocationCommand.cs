using MediatR;

namespace Events.Application.Services.Features.Locations.Commands.DeleteLocation;

/// <inheritdoc />
public record DeleteLocationCommand(int LocationId) : IRequest;