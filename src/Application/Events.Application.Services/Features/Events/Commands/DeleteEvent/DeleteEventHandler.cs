using Events.Application.Services.Features.Events.Repositories;
using MediatR;

namespace Events.Application.Services.Features.Events.Commands.DeleteEvent;

/// <summary>
///     Handler для удаления мероприятия.
/// </summary>
/// <param name="eventRepository">Репозиторий мероприятий.</param>
public class DeleteEventHandler(IEventRepository eventRepository) : IRequestHandler<DeleteEventQuery>
{
    public async Task Handle(DeleteEventQuery request, CancellationToken cancellationToken)
    {
        var @event = await eventRepository.GetByIdAsync(request.EventId);

        await eventRepository.DeleteAsync(@event);
    }
}