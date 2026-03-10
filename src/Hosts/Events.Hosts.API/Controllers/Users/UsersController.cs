using Events.Application.Services.Features.Users.Commands.CreateUser;
using Events.Application.Services.Features.Users.Queries.GetByFilter;
using Events.Contracts.Errors;
using Events.Contracts.Features.Users.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Events.Hosts.API.Controllers.Users;

/// <summary>
///     Контроллер пользователей.
/// </summary>
/// <param name="mediator">Медиатор.</param>
[ApiController]
[Route("api/v/1/[controller]")]
[ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError, "application/problem+json",
    Description = "Неожиданная ошибка сервера.")]
public class UsersController(IMediator mediator) : ControllerBase
{
    /// <summary>
    ///     Получить всех пользователей, удовлетворяющих фильтру.
    /// </summary>
    /// <param name="filter">Фильтр.</param>
    /// <param name="ct">Токен отмены.</param>
    /// <returns>Коллекция пользователей.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<ShortUserDto>), StatusCodes.Status200OK, "application/json",
        Description = "Успех.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest, "application/problem+json",
        Description = "Неправильный запрос.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound, "application/problem+json",
        Description = "Пользователи по фильтру не найдены.")]
    public async Task<IActionResult> GetByFilterAsync([FromQuery] UserFilterDto filter, CancellationToken ct)
    {
        var result = await mediator.Send(new GetUsersByFilter(filter), ct);
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///     Создать пользователя.
    /// </summary>
    /// <param name="dto">Форма создания пользователя.</param>
    /// <param name="ct">Токен отмены.</param>
    /// <returns>ID созданного пользователя.</returns>
    [HttpPost]
    [Consumes("multipart/form-data")]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created, "text/plain",
        Description = "Пользователь создан.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest, "application/problem+json",
        Description = "Неправильный запрос.")]
    public async Task<IActionResult> CreateAsync([FromForm] CreateUserDto dto, CancellationToken ct)
    {
        var id = await mediator.Send(new CreateUserCommand(dto), ct);

        return StatusCode(StatusCodes.Status201Created, id);
    }

    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}