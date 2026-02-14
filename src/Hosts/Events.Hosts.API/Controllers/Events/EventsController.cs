using Events.Application.Services.Features.Events.Commands.CreateEvent;
using Events.Application.Services.Features.Events.Commands.DeleteEvent;
using Events.Application.Services.Features.Events.Queries.GetAllEventsFormats;
using Events.Application.Services.Features.Events.Queries.GetAllEventsTypes;
using Events.Application.Services.Features.Events.Queries.GetEventById;
using Events.Application.Services.Features.Events.Queries.GetEventsByFilter;
using Events.Contracts.Errors;
using Events.Contracts.Features.Events.DTOs;
using Events.Contracts.Features.Events.EventsFormats;
using Events.Contracts.Features.EventsTypes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Events.Hosts.API.Controllers.Events;

/// <summary>
///     Контроллер мероприятий.
/// </summary>
/// <param name="mediator">Медиатор.</param>
[ApiController]
[Route("api/v/1/[controller]")]
[ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError, "application/problem+json",
    Description = "Неожиданная ошибка сервера.")]
public class EventsController(IMediator mediator, ILogger<EventsController> logger) : ControllerBase
{
    /// <summary>
    ///     Получить информацию о мероприятиях, удовлетворяющих фильтру.
    /// </summary>
    /// <param name="filter">Фильтр.</param>
    /// <returns>
    ///     Массив кратких описаний мероприятий, удовлетворяющих фильтру.
    /// </returns>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<ShortEventDto>), StatusCodes.Status200OK, "application/json",
        Description = "Успех.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound, "application/problem+json",
        Description = "Мероприятия по заданному фильтру не найдены.")]
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
    [ProducesResponseType(typeof(EventDto), StatusCodes.Status200OK, "application/json", Description = "Успех.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound, "application/problem+json",
        Description = "Мероприятие не найдено.")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var @event = await mediator.Send(new GetEventByIdQuery(id));

        return Ok(@event);
    }

    /// <summary>
    ///     Создать мероприятие.
    /// </summary>
    /// <param name="dto">Форма создания мероприятия.</param>
    /// <returns>UUID созданного мероприятия.</returns>
    [HttpPost]
    [Consumes("multipart/form-data")]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created, "text/plain",
        Description = "Мероприятие создано.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest, "application/problem+json",
        Description = "Неправильный запрос.")]
    public async Task<IActionResult> CreateAsync([FromForm] CreateEventDto dto)
    {
        var id = await mediator.Send(new CreateEventCommand(dto));

        return StatusCode(StatusCodes.Status201Created, id);
    }

    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///     Удалить мероприятие.
    /// </summary>
    /// <param name="id">Идентификатор мероприятия.</param>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Description = "Успешное удаление.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound, "application/problem+json",
        Description = "Мероприятие не найдено.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest, "application/problem+json",
        Description = "Неправильный запрос.")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        await mediator.Send(new DeleteEventQuery(id));

        return Ok();
    }

    /// <summary>
    ///     Получить все типы мероприятий.
    /// </summary>
    /// <returns>
    ///     Массив типов мероприятий.
    /// </returns>
    [HttpGet("Types")]
    [ProducesResponseType(typeof(IReadOnlyCollection<EventTypeDto>), StatusCodes.Status200OK, "application/json",
        Description = "Успех.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound, "application/problem+json",
        Description = "Типы мероприятий не найдены.")]
    public async Task<IActionResult> GetAllTypesAsync()
    {
        var types = await mediator.Send(new GetAllEventsTypesQuery());

        if (types.Count == 0) return NotFound();

        return Ok(types);
    }

    /// <summary>
    ///     Получить все форматы мероприятий.
    /// </summary>
    /// <returns>Массив форматов мероприятий.</returns>
    [HttpGet("Formats")]
    [ProducesResponseType(typeof(IReadOnlyCollection<EventFormatDto>), StatusCodes.Status200OK, "application/json",
        Description = "Успех.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound, "application/problem+json",
        Description = "Форматы мероприятий не найдены.")]
    public async Task<IActionResult> GetAllFormatsAsync()
    {
        var formats = await mediator.Send(new GetAllEventsFormatsQuery());

        if (formats.Count == 0) return NotFound();

        return Ok(formats);
    }
}