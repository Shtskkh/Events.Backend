using Events.Contracts.Features.Events.DTOs;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetById;

public record GetEventByIdQuery(
    Guid Id
) : IRequest<EventDto>;