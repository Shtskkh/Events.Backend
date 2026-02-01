using AutoMapper;
using Events.Application.Services.Features.Events.Repositories;
using Events.Contracts.Features.Events.DTOs;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetById;

/// <summary>
///     Handler для получения мероприятия по ID.
/// </summary>
/// <param name="eventRepository">Репозиторий мероприятий.</param>
/// <param name="mapper">Маппер.</param>
public class GetEventByIdHandler(IEventRepository eventRepository, IMapper mapper)
    : IRequestHandler<GetEventByIdQuery, EventDto>
{
    /// <summary>
    ///     Метод исполнения запрос.
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>
    ///     DTO мероприятия.
    /// </returns>
    public async Task<EventDto> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
    {
        var @event = await eventRepository.GetByIdAsync(request.Id);
        return mapper.Map<EventDto>(@event);
    }
}