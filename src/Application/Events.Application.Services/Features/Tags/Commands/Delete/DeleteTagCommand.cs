using MediatR;

namespace Events.Application.Services.Features.Tags.Commands.Delete;

public sealed record DeleteTagCommand(int TagId) : IRequest;