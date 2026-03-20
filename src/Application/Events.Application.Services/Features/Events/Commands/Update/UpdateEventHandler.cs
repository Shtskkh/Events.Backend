using Events.Application.Services.Features.Events.Repositories;
using MediatR;

namespace Events.Application.Services.Features.Events.Commands.Update;

/// <inheritdoc />
public class UpdateEventHandler(IEventRepository eventRepository) : IRequestHandler<UpdateEventCommand>
{
    /// <inheritdoc />
    public async Task Handle(UpdateEventCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;
        var @event = await eventRepository.GetByIdAsync(request.Id, cancellationToken);

        if (!string.IsNullOrEmpty(dto.Title))
            @event.ChangeTitle(dto.Title);

        if (!string.IsNullOrEmpty(dto.Announcement))
            @event.ChangeAnnouncement(dto.Announcement);

        if (!string.IsNullOrEmpty(dto.Description))
            @event.ChangeDescription(dto.Description);

        await eventRepository.UpdateAsync(@event, cancellationToken);
    }
}