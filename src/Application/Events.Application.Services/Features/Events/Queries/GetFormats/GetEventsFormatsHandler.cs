using AutoMapper;
using Events.Application.Services.Shared;
using Events.Contracts.Events.EventsFormats;
using Events.Domain.Aggregates.Events;
using Events.Domain.Aggregates.Events.Errors;
using Events.Domain.Exceptions;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetFormats;

public sealed class GetEventsFormatsHandler(IRepository<EventFormat> eventFormatRepository, IMapper mapper)
    : IRequestHandler<GetEventsFormatsQuery, IReadOnlyCollection<EventFormatDto>>
{
    public async Task<IReadOnlyCollection<EventFormatDto>> Handle(GetEventsFormatsQuery request,
        CancellationToken cancellationToken)
    {
        var types = await eventFormatRepository.ListAsync(cancellationToken);

        if (types.Count == 0)
            throw new NotFoundException(EventErrorMessages.Format.NotFoundAny);

        return mapper.Map<IReadOnlyCollection<EventFormatDto>>(types);
    }
}