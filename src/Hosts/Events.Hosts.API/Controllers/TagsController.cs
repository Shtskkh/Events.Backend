using Events.Application.Services.Features.Tags.Commands.Create;
using Events.Contracts.Errors;
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
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(IReadOnlyList<int>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDto))]
    public async Task<IActionResult> CreateAsync([FromBody] IReadOnlyCollection<string> tags,
        CancellationToken cancellationToken)
    {
        var ids = await mediator.Send(new CreateTagsCommand(tags), cancellationToken);
        return StatusCode(StatusCodes.Status201Created, ids);
    }
}