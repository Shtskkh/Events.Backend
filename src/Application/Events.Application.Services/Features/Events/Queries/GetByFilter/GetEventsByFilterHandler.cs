using AutoMapper;
using Events.Application.Services.Features.Events.Repositories;
using Events.Application.Services.Features.Events.Specifications;
using Events.Contracts.Events;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetByFilter;

/// <inheritdoc />
public sealed class GetEventsByFilterHandler(IEventRepository repository, IMapper mapper)
    : IRequestHandler<GetEventsByFilterQuery, IReadOnlyCollection<ShortEventDto>>
{
    /// <inheritdoc />
    public async Task<IReadOnlyCollection<ShortEventDto>> Handle(GetEventsByFilterQuery request,
        CancellationToken cancellationToken)
    {
        var spec = new EventFilterSpec(request.Filter);
        var events = await repository.ListAsync(spec, cancellationToken, request.Filter.Text);

        var dtoList = mapper.Map<List<ShortEventDto>>(events);

        return dtoList.AsReadOnly();
    }
}