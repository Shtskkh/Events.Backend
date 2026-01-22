using Events.Application.Services.Features.Events.Queries.GetById;
using Events.Domain.Aggregates.EventAggregate;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Events.Hosts.API.Controllers.Events;

[ApiController]
[Route("api/v/1/[controller]")]
public class EventsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(ICollection<Event>), StatusCodes.Status200OK, "application/json")]
    public async Task<IActionResult> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var @event = await mediator.Send(new GetEventByIdQuery(id));

        return Ok(@event);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync()
    {
        throw new NotImplementedException();
    }

    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}