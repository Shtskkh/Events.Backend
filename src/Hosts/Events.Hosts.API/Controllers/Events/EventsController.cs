using Events.Application.Services.Features.Events.Queries.GetById;
using Events.Contracts.Features.Events.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Events.Hosts.API.Controllers.Events;

[ApiController]
[Route("api/v/1/[controller]")]
public class EventsController(IMediator mediator, ILogger<EventsController> logger) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<ShortEventDto>), StatusCodes.Status200OK, "application/json")]
    public async Task<IActionResult> GetByFilterAsync([FromQuery] EventFilterDto filter)
    {
        return Ok();
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