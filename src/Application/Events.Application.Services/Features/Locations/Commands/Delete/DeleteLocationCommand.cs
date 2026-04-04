using MediatR;

namespace Events.Application.Services.Features.Locations.Commands.Delete;

/// <inheritdoc />
public record DeleteLocationCommand(int LocationId) : IRequest;