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

        if (dto.StartDateTime.HasValue && dto.EndDateTime.HasValue)
        {
            @event.ChangeDateTimeRange(dto.StartDateTime.Value, dto.EndDateTime.Value);
        }
        else
        {
            if (dto.StartDateTime.HasValue)
                @event.ChangeStartDateTime(dto.StartDateTime.Value);

            if (dto.EndDateTime.HasValue)
                @event.ChangeEndDateTime(dto.EndDateTime.Value);
        }


        await eventRepository.UpdateAsync(@event, cancellationToken);
    }
}