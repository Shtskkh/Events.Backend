using Events.Application.Services.Features.Events.Commands.AddParticipant;
using Events.Application.Services.Features.Events.Commands.AddTag;
using Events.Application.Services.Features.Events.Commands.Create;
using Events.Application.Services.Features.Events.Commands.Delete;
using Events.Application.Services.Features.Events.Commands.RemoveParticipant;
using Events.Application.Services.Features.Events.Commands.RemoveTag;
using Events.Application.Services.Features.Events.Commands.Update;
using Events.Application.Services.Features.Events.Queries.GetByFilter;
using Events.Application.Services.Features.Events.Queries.GetById;
using Events.Application.Services.Features.Events.Queries.GetEventAnalytics;
using Events.Application.Services.Features.Events.Queries.GetEventFormatsAnalytics;
using Events.Application.Services.Features.Events.Queries.GetFormats;
using Events.Application.Services.Features.Events.Queries.GetLocationAnalytics;
using Events.Application.Services.Features.Events.Queries.GetParticipants;
using Events.Application.Services.Features.Events.Queries.GetPlaceholders;
using Events.Application.Services.Features.Events.Queries.GetPlacesAnalytics;
using Events.Application.Services.Features.Events.Queries.GetTagsAnalytics;
using Events.Application.Services.Features.Events.Queries.GetTypes;
using Events.Application.Services.Features.Events.Queries.GetTypesAnalytics;
using Events.Contracts.Errors;
using Events.Contracts.Events;
using Events.Contracts.Events.EventsFormats;
using Events.Contracts.Events.EventsTypes;
using Events.Contracts.Events.Participants;
using Events.Contracts.Locations;
using Events.Contracts.Places;
using Events.Contracts.Tags;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Events.Hosts.API.Controllers;

[ApiController]
[Route("api/v/1/[controller]")]
[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDto))]
public class EventsController(IMediator mediator) : ControllerBase
{
    /// <summary>
    ///     Создать мероприятие.
    /// </summary>
    /// <param name="createEventDto">Форма создания мероприятия.</param>
    /// <param name="ct">Токен отмены.</param>
    /// <returns>UUID созданного мероприятия.</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Guid))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    public async Task<IActionResult> CreateAsync([FromForm] CreateEventDto createEventDto, CancellationToken ct)
    {
        var eventId = await mediator.Send(new CreateEventCommand(createEventDto), ct);
        return StatusCode(StatusCodes.Status201Created, eventId);
    }

    /// <summary>
    ///     Получить мероприятия по фильтру.
    /// </summary>
    /// <param name="eventFilterDto">Фильтр для выборки мероприятий.</param>
    /// <param name="ct">Токен отмены.</param>
    /// <returns>Коллекция мероприятий.</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyCollection<ShortEventDto>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    public async Task<IActionResult> GetByFilterAsync([FromQuery] EventFilterDto eventFilterDto, CancellationToken ct)
    {
        var events = await mediator.Send(new GetEventsByFilterQuery(eventFilterDto), ct);
        return Ok(events);
    }

    /// <summary>
    ///     Получить мероприятие по ID.
    /// </summary>
    /// <param name="eventId">Идентификатор мероприятия.</param>
    /// <param name="ct">Токен отмены.</param>
    /// <returns>Полная информация о мероприятии.</returns>
    [HttpGet("{eventId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EventDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    public async Task<IActionResult> GetByIdAsync(Guid eventId, CancellationToken ct)
    {
        var @event = await mediator.Send(new GetEventByIdQuery(eventId), ct);
        return Ok(@event);
    }

    /// <summary>
    ///     Получить аналитику мероприятия.
    /// </summary>
    /// <param name="eventId">Идентификатор мероприятия.</param>
    /// <param name="ct">Токен отмены.</param>
    /// <returns>Модель аналитики мероприятия.</returns>
    [HttpGet("{eventId:guid}/analytics")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EventAnalyticsDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    public async Task<IActionResult> GetAnalyticsAsync(Guid eventId, CancellationToken ct)
    {
        var analytics = await mediator.Send(new GetEventAnalyticsQuery(eventId), ct);
        return Ok(analytics);
    }

    /// <summary>
    ///     Обновить мероприятие.
    /// </summary>
    /// <param name="eventId">Идентификатор мероприятия.</param>
    /// <param name="updateEventDto">Форма обновления мероприятия.</param>
    /// <param name="ct">Токен отмены.</param>
    [HttpPatch("{eventId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    public async Task<IActionResult> UpdateAsync(Guid eventId, [FromForm] UpdateEventDto updateEventDto,
        CancellationToken ct)
    {
        await mediator.Send(new UpdateEventCommand(eventId, updateEventDto), ct);
        return Ok();
    }

    /// <summary>
    ///     Удалить мероприятие.
    /// </summary>
    /// <param name="eventId">Идентификатор мероприятия.</param>
    /// <param name="ct">Токен отмены.</param>
    [HttpDelete("{eventId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    public async Task<IActionResult> DeleteAsync(Guid eventId, CancellationToken ct)
    {
        await mediator.Send(new DeleteEventQuery(eventId), ct);
        return Ok();
    }

    /// <summary>
    ///     Добавить тэг мероприятию.
    /// </summary>
    /// <param name="eventId">Идентификатор мероприятия.</param>
    /// <param name="tagId">Идентификатор тэга.</param>
    /// <param name="ct">Токен отмены.</param>
    [HttpPost("{eventId:guid}/tags/{tagId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDto))]
    public async Task<IActionResult> AddTagAsync(Guid eventId, int tagId, CancellationToken ct)
    {
        await mediator.Send(new AddTagCommand(eventId, tagId), ct);
        return Ok();
    }

    /// <summary>
    ///     Получить аналитику тэгов мероприятий.
    /// </summary>
    /// <param name="from">Начало периода (необязательно).</param>
    /// <param name="to">Окончание периода (необязательно).</param>
    /// <param name="top">Количество записей в выборке (необязательно).</param>
    /// <param name="ct">Токен отмены.</param>
    /// <returns>Коллекция тэгов с количеством использований за период.</returns>
    [HttpGet("tags/analytics")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyCollection<TagAnalytics>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    public async Task<IActionResult> GetTagsAnalyticsAsync(
        [FromQuery] DateTimeOffset? from,
        [FromQuery] DateTimeOffset? to,
        [FromQuery] int? top,
        CancellationToken ct)
    {
        var analytics = await mediator.Send(new GetEventsTagsAnalyticsQuery(from, to, top), ct);
        return Ok(analytics);
    }

    /// <summary>
    ///     Удалить тэг мероприятия.
    /// </summary>
    /// <param name="eventId">Идентификатор мероприятия.</param>
    /// <param name="tagId">Идентификатор тэга.</param>
    /// <param name="ct">Токен отмены.</param>
    [HttpDelete("{eventId:guid}/tags/{tagId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    public async Task<IActionResult> RemoveTagAsync(Guid eventId, int tagId, CancellationToken ct)
    {
        await mediator.Send(new RemoveTagCommand(eventId, tagId), ct);
        return Ok();
    }

    /// <summary>
    ///     Зарегистрироваться на мероприятие.
    /// </summary>
    /// <param name="eventId">Идентификатор мероприятия.</param>
    /// <param name="participantId">Идентификатор участника (пользователя).</param>
    /// <param name="ct">Токен отмены.</param>
    [HttpPost("{eventId:guid}/participants")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    public async Task<IActionResult> AddParticipantAsync([FromRoute] Guid eventId, [FromQuery] Guid participantId,
        CancellationToken ct)
    {
        await mediator.Send(new AddParticipantCommand(eventId, participantId), ct);
        return Created();
    }

    /// <summary>
    ///     Получить участников мероприятия.
    /// </summary>
    /// <param name="eventId">Идентификатор мероприятия.</param>
    /// <param name="ct">Токен отмены.</param>
    /// <returns>Коллекция участников мероприятия.</returns>
    [HttpGet("{eventId:guid}/participants")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyCollection<ParticipantDto>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    public async Task<IActionResult> GetParticipantsAsync(Guid eventId, CancellationToken ct)
    {
        var participants = await mediator.Send(new GetParticipantsQuery(eventId), ct);
        return Ok(participants);
    }

    /// <summary>
    ///     Покинуть мероприятие.
    /// </summary>
    /// <param name="eventId">Идентификатор мероприятия.</param>
    /// <param name="participantId">Идентификатор участника (пользователя).</param>
    /// <param name="ct">Токен отмены.</param>
    [HttpDelete("{eventId:guid}/participants")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    public async Task<IActionResult> RemoveParticipantAsync([FromRoute] Guid eventId, [FromQuery] Guid participantId,
        CancellationToken ct)
    {
        await mediator.Send(new RemoveParticipantCommand(eventId, participantId), ct);
        return Ok();
    }

    /// <summary>
    ///     Получить все типы мероприятий.
    /// </summary>
    /// <param name="ct">Токен отмены.</param>
    /// <returns>Коллекция типов мероприятий.</returns>
    [HttpGet("types")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyCollection<EventTypeDto>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    public async Task<IActionResult> GetAllTypesAsync(CancellationToken ct)
    {
        var types = await mediator.Send(new GetEventsTypesQuery(), ct);
        return Ok(types);
    }

    /// <summary>
    ///     Получить аналитику по типам мероприятий.
    /// </summary>
    /// <param name="start">Начало периода (необязательно).</param>
    /// <param name="end">Окончание периода (необязательно).</param>
    /// <param name="ct">Токен отмены.</param>
    /// <returns>Коллекция типов мероприятий с количеством за период.</returns>
    [HttpGet("types/analytics")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyCollection<EventTypeAnalyticsDto>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    public async Task<IActionResult> GetTypesAnalyticsAsync(
        [FromQuery] DateTimeOffset? start,
        [FromQuery] DateTimeOffset? end,
        CancellationToken ct)
    {
        var analytics = await mediator.Send(new GetEventTypesAnalytics(start, end), ct);
        return Ok(analytics);
    }

    /// <summary>
    ///     Получить все форматы мероприятий.
    /// </summary>
    /// <param name="ct">Токен отмены.</param>
    /// <returns>Коллекция форматов мероприятий.</returns>
    [HttpGet("formats")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyCollection<EventFormatDto>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    public async Task<IActionResult> GetAllFormatsAsync(CancellationToken ct)
    {
        var formats = await mediator.Send(new GetEventsFormatsQuery(), ct);
        return Ok(formats);
    }

    /// <summary>
    ///     Получить аналитику по форматам мероприятий.
    /// </summary>
    /// <param name="start">Начало периода (необязательно).</param>
    /// <param name="end">Окончание периода (необязательно).</param>
    /// <param name="ct">Токен отмены.</param>
    /// <returns>Коллекция форматов мероприятий с количеством за период.</returns>
    [HttpGet("formats/analytics")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyCollection<EventFormatAnalyticsDto>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    public async Task<IActionResult> GetFormatsAnalyticsAsync(
        [FromQuery] DateTimeOffset? start,
        [FromQuery] DateTimeOffset? end,
        CancellationToken ct)
    {
        var analytics = await mediator.Send(new GetEventFormatsAnalyticsQuery(start, end), ct);
        return Ok(analytics);
    }

    /// <summary>
    ///     Получить ключи файлов плейсхолдеров для мероприятий.
    /// </summary>
    /// <param name="ct">Токен отмены.</param>
    /// <returns>Коллекция ключей плейсхолдеров.</returns>
    [HttpGet("placeholders")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyCollection<string>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    public async Task<IActionResult> GetAllPlaceholdersAsync(CancellationToken ct)
    {
        var placeholders = await mediator.Send(new GetEventsPlaceholdersQuery(), ct);
        return Ok(placeholders);
    }

    /// <summary>
    ///     Получить аналитику по локациям мероприятий.
    /// </summary>
    /// <param name="from">Начало периода (необязательно).</param>
    /// <param name="to">Окончание периода (необязательно).</param>
    /// <param name="ct">Токен отмены.</param>
    /// <returns>Коллекция локаций с количеством их использования за период.</returns>
    [HttpGet("locations/analytics")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyCollection<LocationAnalyticsDto>))]
    public async Task<IActionResult> GetLocationsAnalyticsAsync(
        [FromQuery] DateTimeOffset? from, [FromQuery] DateTimeOffset? to, CancellationToken ct)
    {
        var analytics = await mediator.Send(new GetEventsLocationsAnalyticsQuery(from, to), ct);
        return Ok(analytics);
    }

    /// <summary>
    ///     Получить аналитику по помещениям мероприятий.
    /// </summary>
    /// <param name="from">Начало периода (необязательно).</param>
    /// <param name="to">Окончание периода (необязательно).</param>
    /// <param name="top">Количество записей в выборке (необязательно).</param>
    /// <param name="ct">Токен отмены.</param>
    /// <returns>Коллекция помещений с количеством их использования за период.</returns>
    [HttpGet("places/analytics")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyCollection<PlaceAnalyticsDto>))]
    public async Task<IActionResult> GetPlacesAnalyticsAsync(
        [FromQuery] DateTimeOffset? from, [FromQuery] DateTimeOffset? to, [FromQuery] int? top,
        CancellationToken ct)
    {
        var analytics = await mediator.Send(new GetEventsPlacesAnalyticsQuery(from, to, top), ct);
        return Ok(analytics);
    }
}