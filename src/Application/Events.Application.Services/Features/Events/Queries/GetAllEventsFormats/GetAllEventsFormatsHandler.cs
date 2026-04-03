using AutoMapper;
using Events.Application.Services.Features.Events.Repositories;
using Events.Contracts.Events.EventsFormats;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetAllEventsFormats;

/// <summary>
///     Handler для получения всех форматов мероприятий.
/// </summary>
/// <param name="eventFormatRepository">Репозиторий форматов мероприятий.</param>
/// <param name="mapper">Маппер.</param>
public class GetAllEventsFormatsHandler(IEventFormatRepository eventFormatRepository, IMapper mapper)
    : IRequestHandler<GetAllEventsFormatsQuery, IReadOnlyCollection<EventFormatDto>>
{
    public async Task<IReadOnlyCollection<EventFormatDto>> Handle(GetAllEventsFormatsQuery request,
        CancellationToken cancellationToken)
    {
        var types = await eventFormatRepository.GetAllAsync(cancellationToken);

        return mapper.Map<IReadOnlyCollection<EventFormatDto>>(types);
    }
}