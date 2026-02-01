using Events.Application.Services.Features.Events.Queries.GetByFilter;
using Events.Application.Services.Features.Events.Queries.GetById;
using Events.Contracts.Features.Events.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Events.Hosts.API.Controllers.Events;

/// <summary>
///     Контроллер для мероприятий.
/// </summary>
/// <param name="mediator">Медиатор.</param>
[ApiController]
[Route("api/v/1/[controller]")]
public class EventsController(IMediator mediator) : ControllerBase
{
    /// <summary>
    ///     Получить информацию о мероприятиях, удовлетворяющих фильтру.
    /// </summary>
    /// <param name="filter">Фильтр.</param>
    /// <returns>
    ///     Массив кратких описаний мероприятий, удовлетворяющих фильтру.
    /// </returns>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<ShortEventDto>), StatusCodes.Status200OK, "application/json")]
    [ProducesResponseType(typeof(NotFoundResult), StatusCodes.Status404NotFound, "application/problem+json")]
    public async Task<IActionResult> GetByFilterAsync([FromQuery] EventFilterDto filter)
    {
        var events = await mediator.Send(new GetEventsByFilterQuery(filter));

        if (events.Count == 0) return NotFound();

        return Ok(events);
    }

    /// <summary>
    ///     Получить информацию о мероприятии по ID.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <returns>
    ///     Полная информация о мероприятии.
    /// </returns>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(EventDto), StatusCodes.Status200OK, "application/json")]
    [ProducesResponseType(typeof(NotFoundResult), StatusCodes.Status404NotFound, "application/problem+json")]
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