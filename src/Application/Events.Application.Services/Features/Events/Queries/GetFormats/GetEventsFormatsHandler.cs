using AutoMapper;
using Events.Application.Services.Shared;
using Events.Contracts.Events.EventsFormats;
using Events.Domain.Aggregates.Events;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetFormats;

/// <summary>
///     Handler для получения всех форматов мероприятий.
/// </summary>
/// <param name="eventFormatRepository">Репозиторий форматов мероприятий.</param>
/// <param name="mapper">Маппер.</param>
public sealed class GetEventsFormatsHandler(IRepository<EventFormat> eventFormatRepository, IMapper mapper)
    : IRequestHandler<GetEventsFormatsQuery, IReadOnlyCollection<EventFormatDto>>
{
    public async Task<IReadOnlyCollection<EventFormatDto>> Handle(GetEventsFormatsQuery request,
        CancellationToken cancellationToken)
    {
        var types = await eventFormatRepository.ListAsync(cancellationToken);

        return mapper.Map<IReadOnlyCollection<EventFormatDto>>(types);
    }
}