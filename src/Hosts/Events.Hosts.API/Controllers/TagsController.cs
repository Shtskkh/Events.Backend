using Events.Application.Services.Features.Tags.Commands.Create;
using Events.Application.Services.Features.Tags.Commands.Delete;
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
[Route("api/v/1/[controller]")]
[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDto))]
public class TagsController(IMediator mediator) : ControllerBase
{
    /// <summary>
    ///     Создать тэг.
    /// </summary>
    /// <param name="tag">Тэг.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>ID созданных тэгов в порядке изначальной передачи.</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(int))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDto))]
    public async Task<IActionResult> CreateAsync([FromBody] string tag,
        CancellationToken cancellationToken)
    {
        var ids = await mediator.Send(new CreateTagCommand(tag), cancellationToken);
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
    public async Task<IActionResult> GetByFilterAsync([FromQuery] TagFilterDto filter,
        CancellationToken cancellationToken)
    {
        var tags = await mediator.Send(new GetTagsByFilterQuery(filter), cancellationToken);
        return Ok(tags);
    }

    /// <summary>
    ///     Удалить тэг.
    /// </summary>
    /// <param name="tagId">ID.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    [HttpDelete("{tagId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    public async Task<IActionResult> DeleteAsync(int tagId, CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteTagCommand(tagId), cancellationToken);
        return Ok();
    }
}