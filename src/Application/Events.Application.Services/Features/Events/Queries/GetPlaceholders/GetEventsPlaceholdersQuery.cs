using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetPlaceholders;

public sealed record GetEventsPlaceholdersQuery : IRequest<IReadOnlyCollection<string>>;