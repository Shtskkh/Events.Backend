using Events.Application.Services.Features.Events.Commands.AddParticipant;
using Events.Application.Services.Features.Events.Commands.CreateEvent;
using Events.Application.Services.Features.Events.Commands.DeleteEvent;
using Events.Application.Services.Features.Events.Queries.GetAllEventsFormats;
using Events.Application.Services.Features.Events.Queries.GetAllEventsPlaceholders;
using Events.Application.Services.Features.Events.Queries.GetAllEventsTypes;
using Events.Application.Services.Features.Events.Queries.GetEventById;
using Events.Application.Services.Features.Events.Queries.GetEventsByFilter;
using Events.Contracts.Errors;
using Events.Contracts.Features.Events.DTOs;
using Events.Contracts.Features.Events.EventsFormats;
using Events.Contracts.Features.Events.EventsTypes;
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
    ///     Получить мероприятия, удовлетворяющие фильтру.
    /// </summary>
    /// <param name="filter">Фильтр.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns> Коллекция мероприятий.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<ShortEventDto>), StatusCodes.Status200OK, "application/json",
        Description = "Успех.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest, "application/problem+json",
        Description = "Неправильный запрос.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound, "application/problem+json",
        Description = "Мероприятия по заданному фильтру не найдены.")]
    public async Task<IActionResult> GetByFilterAsync([FromQuery] EventFilterDto filter,
        CancellationToken cancellationToken)
    {
        var events = await mediator.Send(new GetEventsByFilterQuery(filter), cancellationToken);

        return Ok(events);
    }

    /// <summary>
    ///     Получить мероприятие по ID.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Полная информация о мероприятии. </returns>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(EventDto), StatusCodes.Status200OK, "application/json", Description = "Успех.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound, "application/problem+json",
        Description = "Мероприятие не найдено.")]
    public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var @event = await mediator.Send(new GetEventByIdQuery(id), cancellationToken);

        return Ok(@event);
    }

    /// <summary>
    ///     Создать мероприятие.
    /// </summary>
    /// <param name="dto">Форма создания мероприятия.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>UUID созданного мероприятия.</returns>
    [HttpPost]
    [Consumes("multipart/form-data")]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created, "text/plain",
        Description = "Мероприятие создано.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest, "application/problem+json",
        Description = "Неправильный запрос.")]
    public async Task<IActionResult> CreateAsync([FromForm] CreateEventDto dto, CancellationToken cancellationToken)
    {
        var id = await mediator.Send(new CreateEventCommand(dto), cancellationToken);

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
    /// <param name="cancellationToken">Токен отмены.</param>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Description = "Успешное удаление.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest, "application/problem+json",
        Description = "Неправильный запрос.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound, "application/problem+json",
        Description = "Мероприятие не найдено.")]
    public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteEventQuery(id), cancellationToken);

        return Ok();
    }

    /// <summary>
    ///     Зарегистрироваться на  мероприятие.
    /// </summary>
    /// <param name="eventId">Идентификатор мероприятия.</param>
    /// <param name="participantId">Идентификатор участника.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    [HttpPost("{eventId:guid}/participants/{participantId:guid}")]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created, "text/plain",
        Description = "Мероприятие создано.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest, "application/problem+json",
        Description = "Неправильный запрос.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound, "application/problem+json",
        Description = "Мероприятие или пользователь не найден.")]
    public async Task<IActionResult> AddParticipantAsync(Guid eventId, Guid participantId,
        CancellationToken cancellationToken)
    {
        await mediator.Send(new AddParticipantCommand(eventId, participantId), cancellationToken);

        return Created();
    }

    /// <summary>
    ///     Получить все типы мероприятий.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекция типов мероприятий.</returns>
    [HttpGet("Types")]
    [ProducesResponseType(typeof(IReadOnlyCollection<EventTypeDto>), StatusCodes.Status200OK, "application/json",
        Description = "Успех.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound, "application/problem+json",
        Description = "Типы мероприятий не найдены.")]
    public async Task<IActionResult> GetAllTypesAsync(CancellationToken cancellationToken)
    {
        var types = await mediator.Send(new GetAllEventsTypesQuery(), cancellationToken);

        if (types.Count == 0) return NotFound();

        return Ok(types);
    }

    /// <summary>
    ///     Получить все форматы мероприятий.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекция форматов мероприятий.</returns>
    [HttpGet("Formats")]
    [ProducesResponseType(typeof(IReadOnlyCollection<EventFormatDto>), StatusCodes.Status200OK, "application/json",
        Description = "Успех.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound, "application/problem+json",
        Description = "Форматы мероприятий не найдены.")]
    public async Task<IActionResult> GetAllFormatsAsync(CancellationToken cancellationToken)
    {
        var formats = await mediator.Send(new GetAllEventsFormatsQuery(), cancellationToken);

        if (formats.Count == 0) return NotFound();

        return Ok(formats);
    }

    /// <summary>
    ///     Получить ключи файлов плейсхолдеров для мероприятий.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекция плейсхолдеров.</returns>
    [HttpGet("Placeholders")]
    [ProducesResponseType(typeof(IReadOnlyCollection<string>), StatusCodes.Status200OK, "application/json",
        Description = "Успех.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound, "application/problem+json",
        Description = "Плейсхолдеры мероприятий не найдены.")]
    public async Task<IActionResult> GetAllEventsPlaceholders(CancellationToken cancellationToken)
    {
        var dtoList = await mediator.Send(new GetAllEventsPlaceholdersQuery(), cancellationToken);

        return Ok(dtoList);
    }
}