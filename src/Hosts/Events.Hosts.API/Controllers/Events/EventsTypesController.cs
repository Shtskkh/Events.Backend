using Events.Application.Services.Features.EventsTypes.Queries.GetAll;
using Events.Contracts.Errors;
using Events.Contracts.Features.EventsTypes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Events.Hosts.API.Controllers.Events;

/// <summary>
///     Контроллер типов мероприятий.
/// </summary>
/// <param name="mediator">Медиатор.</param>
[ApiController]
[Route("api/v/1/[controller]")]
[ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError, "application/problem+json",
    Description = "Неожиданная ошибка сервера.")]
public class EventsTypesController(IMediator mediator) : ControllerBase
{
    /// <summary>
    ///     Получить все типы мероприятий.
    /// </summary>
    /// <returns>
    ///     Массив типов мероприятий.
    /// </returns>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<EventTypeDto>), StatusCodes.Status200OK, "application/json",
        Description = "Успех.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound, "application/problem+json",
        Description = "Типы мероприятий не найдены.")]
    public async Task<IActionResult> GetAllAsync()
    {
        var types = await mediator.Send(new GetAllEventsTypesQuery());

        if (types.Count == 0) return NotFound();

        return Ok(types);
    }
}