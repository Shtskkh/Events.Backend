using AutoMapper;
using Events.Application.Services.Features.Events.Repositories;
using Events.Application.Services.Features.Events.Specifications;
using Events.Contracts.Features.Events.DTOs;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetEventsByFilter;

/// <inheritdoc />
public class GetEventsByFilterHandler(IEventRepository repository, IMapper mapper)
    : IRequestHandler<GetEventsByFilterQuery, IReadOnlyCollection<ShortEventDto>>
{
    /// <inheritdoc />
    public async Task<IReadOnlyCollection<ShortEventDto>> Handle(GetEventsByFilterQuery request,
        CancellationToken cancellationToken)
    {
        var spec = new EventFilterSpecification(request.filter);
        var events = await repository.GetByFilterAsync(spec);

        var dtoList = mapper.Map<List<ShortEventDto>>(events);

        return dtoList.AsReadOnly();
    }
}