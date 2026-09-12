using MediatR;

namespace Events.Application.Services.Features.Locations.Commands.Delete;

public sealed record DeleteLocationCommand(int LocationId) : IRequest;