using AutoMapper;
using Events.Application.Services.Features.Events.Repositories;
using Events.Contracts.Events.EventsFormats;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetFormats;

/// <summary>
///     Handler для получения всех форматов мероприятий.
/// </summary>
/// <param name="eventFormatRepository">Репозиторий форматов мероприятий.</param>
/// <param name="mapper">Маппер.</param>
public class GetEventsFormatsHandler(IEventFormatRepository eventFormatRepository, IMapper mapper)
    : IRequestHandler<GetEventsFormatsQuery, IReadOnlyCollection<EventFormatDto>>
{
    public async Task<IReadOnlyCollection<EventFormatDto>> Handle(GetEventsFormatsQuery request,
        CancellationToken cancellationToken)
    {
        var types = await eventFormatRepository.GetAllAsync(cancellationToken);

        return mapper.Map<IReadOnlyCollection<EventFormatDto>>(types);
    }
}