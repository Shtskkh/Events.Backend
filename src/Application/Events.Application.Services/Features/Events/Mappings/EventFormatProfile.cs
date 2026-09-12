using AutoMapper;
using Events.Contracts.Events.EventsFormats;
using Events.Domain.Aggregates.Events;

namespace Events.Application.Services.Features.Events.Mappings;

/// <summary>
///     Профили маппинга для формата мероприятий.
/// </summary>
public class EventFormatProfile : Profile
{
    public EventFormatProfile()
    {
        CreateMap<EventFormat, EventFormatDto>();
    }
}