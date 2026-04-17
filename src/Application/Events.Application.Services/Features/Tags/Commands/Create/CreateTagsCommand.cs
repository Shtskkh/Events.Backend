using MediatR;

namespace Events.Application.Services.Features.Tags.Commands.Create;

public sealed record CreateTagsCommand(IReadOnlyCollection<string> Tags) : IRequest<IReadOnlyCollection<int>>;