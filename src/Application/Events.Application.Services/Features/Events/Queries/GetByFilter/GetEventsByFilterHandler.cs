using AutoMapper;
using Events.Application.Services.Features.Events.Repositories;
using Events.Application.Services.Features.Events.Specifications;
using Events.Contracts.Events;
using Events.Domain.Aggregates.Events.Errors;
using Events.Domain.Exceptions;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetByFilter;

public sealed class GetEventsByFilterHandler(IEventRepository repository, IMapper mapper)
    : IRequestHandler<GetEventsByFilterQuery, IReadOnlyCollection<ShortEventDto>>
{
    public async Task<IReadOnlyCollection<ShortEventDto>> Handle(GetEventsByFilterQuery request,
        CancellationToken cancellationToken)
    {
        var eventFilterSpec = new EventFilterSpec(request.Filter);
        var events = await repository.ListAsync(eventFilterSpec, cancellationToken, request.Filter.Text);

        if (events.Count == 0)
            throw new NotFoundException(EventErrors.NotFoundByFilter);

        return mapper.Map<IReadOnlyCollection<ShortEventDto>>(events);
    }
}