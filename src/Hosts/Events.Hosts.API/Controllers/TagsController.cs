using Events.Application.Services.Features.Tags.Commands.Create;
using Events.Application.Services.Features.Tags.Queries;
using Events.Contracts.Errors;
using Events.Contracts.Tags;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Events.Hosts.API.Controllers;

/// <summary>
///     Контроллер тэгов.
/// </summary>
/// <param name="mediator">Медиатор.</param>
[ApiController]
[Route("[controller]")]
[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDto))]
public class TagsController(IMediator mediator) : ControllerBase
{
    /// <summary>
    ///     Создать тэги.
    /// </summary>
    /// <param name="tags">Коллекция новых тэгов.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>ID созданных тэгов в порядке изначальной передачи.</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(IReadOnlyCollection<int>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDto))]
    public async Task<IActionResult> CreateAsync([FromBody] IReadOnlyCollection<string> tags,
        CancellationToken cancellationToken)
    {
        var ids = await mediator.Send(new CreateTagsCommand(tags), cancellationToken);
        return StatusCode(StatusCodes.Status201Created, ids);
    }

    /// <summary>
    ///     Получить тэги по фильтру.
    /// </summary>
    /// <param name="filter">Модель фильтра.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Модели тэгов.</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyCollection<TagDto>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    public async Task<IActionResult> GetByFilter([FromQuery] TagFilterDto filter, CancellationToken cancellationToken)
    {
        var tags = await mediator.Send(new GetTagsByFilterQuery(filter), cancellationToken);
        return Ok(tags);
    }
}