using MediatR;

namespace Events.Application.Services.Features.Tags.Commands.Create;

public sealed record CreateTagCommand(string Tag) : IRequest<int>;