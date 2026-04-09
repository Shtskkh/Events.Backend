using Events.Application.Services.Features.Events.Commands.AddParticipant;
using Events.Application.Services.Features.Events.Commands.Create;
using Events.Application.Services.Features.Events.Commands.Delete;
using Events.Application.Services.Features.Events.Commands.RemoveParticipant;
using Events.Application.Services.Features.Events.Commands.Update;
using Events.Application.Services.Features.Events.Queries.GetByFilter;
using Events.Application.Services.Features.Events.Queries.GetById;
using Events.Application.Services.Features.Events.Queries.GetEventAnalytics;
using Events.Application.Services.Features.Events.Queries.GetEventFormatsAnalytics;
using Events.Application.Services.Features.Events.Queries.GetFormats;
using Events.Application.Services.Features.Events.Queries.GetParticipants;
using Events.Application.Services.Features.Events.Queries.GetPlaceholders;
using Events.Application.Services.Features.Events.Queries.GetTypes;
using Events.Application.Services.Features.Events.Queries.GetTypesAnalytics;
using Events.Contracts.Errors;
using Events.Contracts.Events;
using Events.Contracts.Events.EventsFormats;
using Events.Contracts.Events.EventsTypes;
using Events.Contracts.Events.Participants;
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
    ///     Получить аналитику.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Модель аналитики.</returns>
    [HttpGet("{id:guid}/analytics")]
    [ProducesResponseType(typeof(EventAnalyticsDto), StatusCodes.Status200OK, "application/json",
        Description = "Успех.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound, "application/problem+json",
        Description = "Мероприятие не найдено.")]
    public async Task<IActionResult> GetAnalyticsAsync(Guid id, CancellationToken cancellationToken)
    {
        var analytics = await mediator.Send(new GetEventAnalyticsQuery(id), cancellationToken);

        return Ok(analytics);
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


    /// <summary>
    ///     Обновить мероприятие.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="dto">Модель обновления.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPatch("{id:guid}")]
    [Consumes("multipart/form-data")]
    [ProducesResponseType(StatusCodes.Status200OK, Description = "Успех.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest, "application/problem+json",
        Description = "Неправильный запрос.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound, "application/problem+json",
        Description = "Мероприятие не найдено.")]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromForm] UpdateEventDto dto,
        CancellationToken cancellationToken)
    {
        await mediator.Send(new UpdateEventCommand(id, dto), cancellationToken);

        return Ok();
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
    ///     Получить участников мероприятия.
    /// </summary>
    /// <param name="id">Идентификатор мероприятия.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекция участников мероприятия.</returns>
    [HttpGet("{id:guid}/participants")]
    [ProducesResponseType(typeof(IReadOnlyCollection<ParticipantDto>), StatusCodes.Status200OK, "application/json",
        Description = "Успех.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound, "application/problem+json",
        Description = "Мероприятие или участники не найдены.")]
    public async Task<IActionResult> GetParticipants(Guid id, CancellationToken cancellationToken)
    {
        var participants = await mediator.Send(new GetParticipantsQuery(id), cancellationToken);

        return Ok(participants);
    }

    /// <summary>
    ///     Зарегистрироваться на мероприятие.
    /// </summary>
    /// <param name="eventId">Идентификатор мероприятия.</param>
    /// <param name="participantId">Идентификатор участника.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    [HttpPost("{eventId:guid}/participants")]
    [ProducesResponseType(StatusCodes.Status201Created, Description = "Участник добавлен.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest, "application/problem+json",
        Description = "Неправильный запрос.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound, "application/problem+json",
        Description = "Мероприятие или пользователь не найден.")]
    public async Task<IActionResult> AddParticipantAsync([FromRoute] Guid eventId, [FromQuery] Guid participantId,
        CancellationToken cancellationToken)
    {
        await mediator.Send(new AddParticipantCommand(eventId, participantId), cancellationToken);

        return Created();
    }

    /// <summary>
    ///     Покинуть мероприятие.
    /// </summary>
    /// <param name="eventId">Идентификатор мероприятия.</param>
    /// <param name="participantId">Идентификатор участника.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    [HttpDelete("{eventId:guid}/participants")]
    [ProducesResponseType(StatusCodes.Status200OK, Description = "Мероприятие создано.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound, "application/problem+json",
        Description = "Мероприятие или пользователь не найден.")]
    public async Task<IActionResult> RemoveParticipantAsync([FromRoute] Guid eventId, [FromQuery] Guid participantId,
        CancellationToken cancellationToken)
    {
        await mediator.Send(new RemoveParticipantCommand(eventId, participantId), cancellationToken);

        return Ok();
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
        var types = await mediator.Send(new GetEventsTypesQuery(), cancellationToken);

        if (types.Count == 0) return NotFound();

        return Ok(types);
    }

    /// <summary>
    ///     Получить аналитику по типам мероприятий.
    /// </summary>
    /// <param name="start">Начало периода.</param>
    /// <param name="end">Окончание периода.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекция типов мероприятий с количеством за период.</returns>
    [HttpGet("Types/Analytics")]
    [ProducesResponseType(typeof(IReadOnlyCollection<EventTypeAnalytics>),
        StatusCodes.Status200OK,
        "application/json",
        Description = "Успех.")]
    [ProducesResponseType(typeof(ErrorDto),
        StatusCodes.Status404NotFound,
        "application/problem+json",
        Description = "Мероприятия за данный период не были найдены.")]
    public async Task<IActionResult> GetTypesAnalytics(
        [FromQuery] DateTimeOffset start,
        [FromQuery] DateTimeOffset end,
        CancellationToken cancellationToken)
    {
        var analytics = await mediator.Send(new GetEventTypesAnalytics(start, end), cancellationToken);

        return Ok(analytics);
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
        var formats = await mediator.Send(new GetEventsFormatsQuery(), cancellationToken);

        if (formats.Count == 0) return NotFound();

        return Ok(formats);
    }

    /// <summary>
    ///     Получить аналитику по форматам мероприятий.
    /// </summary>
    /// <param name="start">Начало периода.</param>
    /// <param name="end">Окончание периода.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекция типов мероприятий с количеством за период.</returns>
    [HttpGet("Formats/Analytics")]
    [ProducesResponseType(typeof(IReadOnlyCollection<EventFormatAnalytics>),
        StatusCodes.Status200OK,
        "application/json",
        Description = "Успех.")]
    [ProducesResponseType(typeof(ErrorDto),
        StatusCodes.Status404NotFound,
        "application/problem+json",
        Description = "Мероприятия за данный период не были найдены.")]
    public async Task<IActionResult> GetFormatsAnalytics(
        [FromQuery] DateTimeOffset start,
        [FromQuery] DateTimeOffset end,
        CancellationToken cancellationToken)
    {
        var analytics = await mediator.Send(new GetEventFormatsAnalyticsQuery(start, end), cancellationToken);

        return Ok(analytics);
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
        var dtoList = await mediator.Send(new GetEventsPlaceholdersQuery(), cancellationToken);

        return Ok(dtoList);
    }
}