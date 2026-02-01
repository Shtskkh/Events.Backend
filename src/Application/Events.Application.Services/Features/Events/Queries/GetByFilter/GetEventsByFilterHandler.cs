using AutoMapper;
using Events.Application.Services.Features.Events.Repositories;
using Events.Application.Services.Features.Events.Specifications;
using Events.Contracts.Features.Events.DTOs;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetByFilter;

/// <summary>
///     Handler для получения мероприятий по фильтрам.
/// </summary>
/// <param name="repository">Репозиторий мероприятий.</param>
/// <param name="mapper">Маппер.</param>
public class GetEventsByFilterHandler(IEventRepository repository, IMapper mapper)
    : IRequestHandler<GetEventsByFilterQuery, IReadOnlyCollection<ShortEventDto>>
{
    /// <summary>
    ///     Исполнить запрос.
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Иммутабельный список мероприятий.</returns>
    public async Task<IReadOnlyCollection<ShortEventDto>> Handle(GetEventsByFilterQuery request,
        CancellationToken cancellationToken)
    {
        var spec = new EventFilterSpecification(request.filter);
        var events = await repository.GetByFilterAsync(spec);

        return mapper.Map<IReadOnlyCollection<ShortEventDto>>(events);
    }
}