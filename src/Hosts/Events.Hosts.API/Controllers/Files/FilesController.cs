using Events.Application.Services.Features.Files.Queries.GetFile;
using Events.Contracts.Errors;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Events.Hosts.API.Controllers.Files;

/// <summary>
///     Контроллер файлов.
/// </summary>
/// <param name="mediator">Медиатор.</param>
[ApiController]
[Route("api/v/1/[controller]")]
[ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError, "application/problem+json",
    Description = "Неожиданная ошибка сервера.")]
public class FilesController(IMediator mediator) : ControllerBase
{
    /// <summary>
    ///     Скачать файл.
    /// </summary>
    /// <param name="bucket">Название bucket.</param>
    /// <param name="key">Название файла.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Файл.</returns>
    [HttpGet("{bucket}/{key}")]
    [ProducesResponseType(typeof(FileStreamResult), StatusCodes.Status200OK, "application/octet-stream",
        Description = "Успех.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest, "application/problem+json",
        Description = "Неправильный запрос.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound, "application/problem+json",
        Description = "Мероприятия по заданному фильтру не найдены.")]
    public async Task<IActionResult> GetFileAsync(string bucket, string key, CancellationToken cancellationToken)
    {
        var file = await mediator.Send(new GetFileQuery(bucket, key), cancellationToken);

        Response.ContentLength = file.Length;
        return File(file.Content, file.ContentType, file.Filename);
    }
}