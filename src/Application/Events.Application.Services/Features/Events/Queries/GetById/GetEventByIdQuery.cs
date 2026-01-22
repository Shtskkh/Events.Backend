using Events.Contracts.Features.Events.DTOs;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetById;

public class GetEventByIdQuery(Guid id) : IRequest<ShortEventDto>
{
    public Guid Id { get; set; } = id;
}