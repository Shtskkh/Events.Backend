using AutoMapper;
using Events.Application.Services.Features.EventsFormats.Repositories;
using Events.Contracts.Features.Events.EventsFormats;
using MediatR;

namespace Events.Application.Services.Features.EventsFormats.Queries.GetAll;

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
        var types = await eventFormatRepository.GetAllAsync();

        return mapper.Map<IReadOnlyCollection<EventFormatDto>>(types);
    }
}