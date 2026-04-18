using Events.Application.Services.Features.Tags.Commands.Create;
using Events.Application.Services.Features.Tags.Commands.Delete;
using Events.Application.Services.Features.Tags.Queries;
using Events.Contracts.Errors;
using Events.Contracts.Tags;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Events.Hosts.API.Controllers;

[ApiController]
[Route("api/v/1/[controller]")]
[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDto))]
public class TagsController(IMediator mediator) : ControllerBase
{
    /// <summary>
    ///     Создать тэг.
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(int))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDto))]
    public async Task<IActionResult> CreateAsync([FromBody] string tag, CancellationToken ct)
    {
        var tagId = await mediator.Send(new CreateTagCommand(tag), ct);
        return StatusCode(StatusCodes.Status201Created, tagId);
    }

    /// <summary>
    ///     Получить тэги по фильтру.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyCollection<TagDto>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    public async Task<IActionResult> GetByFilterAsync([FromQuery] TagFilterDto filter, CancellationToken ct)
    {
        var tags = await mediator.Send(new GetTagsByFilterQuery(filter), ct);
        return Ok(tags);
    }

    /// <summary>
    ///     Удалить тэг.
    /// </summary>
    [HttpDelete("{tagId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    public async Task<IActionResult> DeleteAsync(int tagId, CancellationToken ct)
    {
        await mediator.Send(new DeleteTagCommand(tagId), ct);
        return Ok();
    }
}