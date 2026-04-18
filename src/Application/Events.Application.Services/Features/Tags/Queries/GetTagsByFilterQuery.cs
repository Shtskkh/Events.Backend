using Events.Contracts.Tags;
using MediatR;

namespace Events.Application.Services.Features.Tags.Queries;

public sealed record GetTagsByFilterQuery(TagFilterDto Filter) : IRequest<IReadOnlyCollection<TagDto>>;