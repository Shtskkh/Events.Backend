using Events.Application.Services.Features.Files.Queries.GetFile;
using Events.Contracts.Errors;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Events.Hosts.API.Controllers;

[ApiController]
[Route("api/v/1/[controller]")]
[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDto))]
public class FilesController(IMediator mediator) : ControllerBase
{
    /// <summary>
    ///     Скачать файл.
    /// </summary>
    /// <param name="bucket">Название бакета хранилища.</param>
    /// <param name="key">Ключ файла в бакете.</param>
    /// <param name="ct">Токен отмены.</param>
    /// <returns>Содержимое файла в виде потока.</returns>
    [HttpGet("{bucket}/{key}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FileStreamResult))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    public async Task<IActionResult> GetFileAsync(string bucket, string key, CancellationToken ct)
    {
        var file = await mediator.Send(new GetFileQuery(bucket, key), ct);

        Response.ContentLength = file.Length;
        return File(file.Content, file.ContentType, file.Filename);
    }
}
