using Events.Application.Services.Features.Users.Commands.Auth;
using Events.Application.Services.Features.Users.Commands.ChangePassword;
using Events.Application.Services.Features.Users.Commands.Create;
using Events.Application.Services.Features.Users.Commands.Delete;
using Events.Application.Services.Features.Users.Queries.GetByFilter;
using Events.Application.Services.Features.Users.Queries.GetById;
using Events.Application.Services.Features.Users.Queries.GetRecentViewedEvents;
using Events.Contracts.Errors;
using Events.Contracts.Events;
using Events.Contracts.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Events.Hosts.API.Controllers;

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
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекция пользователей.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<ShortUserDto>), StatusCodes.Status200OK, "application/json",
        Description = "Успех.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest, "application/problem+json",
        Description = "Неправильный запрос.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound, "application/problem+json",
        Description = "Пользователи по фильтру не найдены.")]
    public async Task<IActionResult> GetByFilterAsync([FromQuery] UserFilterDto filter,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetUsersByFilter(filter), cancellationToken);
        return Ok(result);
    }

    /// <summary>
    ///     Получить пользователя по ID.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Информация о пользователе.</returns>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK, "application/json",
        Description = "Успех.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound, "application/problem+json",
        Description = "Пользователь не найден.")]
    public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await mediator.Send(new GetUserByIdQuery(id), cancellationToken);

        return Ok(user);
    }

    /// <summary>
    ///     Создать пользователя.
    /// </summary>
    /// <param name="dto">Форма создания пользователя.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>ID созданного пользователя.</returns>
    [HttpPost]
    [Consumes("multipart/form-data")]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created, "text/plain",
        Description = "Пользователь создан.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest, "application/problem+json",
        Description = "Неправильный запрос.")]
    public async Task<IActionResult> CreateAsync([FromForm] CreateUserDto dto, CancellationToken cancellationToken)
    {
        var id = await mediator.Send(new CreateUserCommand(dto), cancellationToken);

        return StatusCode(StatusCodes.Status201Created, id);
    }

    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///     Изменить пароль.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="dto">Модель изменения пароля.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    [HttpPatch("{id:guid}/password")]
    [ProducesResponseType(StatusCodes.Status200OK, Description = "Успех.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest, "application/problem+json",
        Description = "Неправильный запрос.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound, "application/problem+json",
        Description = "Пользователь не найден.")]
    public async Task<IActionResult> ChangePassword(Guid id, [FromForm] ChangePasswordDto dto,
        CancellationToken cancellationToken)
    {
        await mediator.Send(new ChangePasswordCommand(id, dto), cancellationToken);

        return Ok();
    }

    /// <summary>
    ///     Удалить пользователя.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Description = "Успех.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound, "application/problem+json",
        Description = "Пользователь не найден.")]
    public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteUserCommand(id), cancellationToken);

        return Ok();
    }

    /// <summary>
    ///     Аутентифицировать пользователя.
    /// </summary>
    /// <param name="dto">Модель аутентификации.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Модель Jwt токена.</returns>
    [HttpPost("login")]
    [ProducesResponseType(typeof(TokenDto), StatusCodes.Status200OK, "application/json",
        Description = "Успех.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status403Forbidden, "application/problem+json",
        Description = "Пользователь не авторизован.")]
    public async Task<IActionResult> AuthAsync([FromForm] AuthDto dto, CancellationToken cancellationToken)
    {
        var tokenDto = await mediator.Send(new AuthUserCommand(dto), cancellationToken);

        return Ok(tokenDto);
    }

    /// <summary>
    ///     Получить последние 10 просмотренных пользователем мероприятий.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекция краткой информации о мероприятиях.</returns>
    [HttpGet("{id:guid}/events/recent")]
    [ProducesResponseType(typeof(IReadOnlyCollection<ShortEventDto>), StatusCodes.Status200OK, "application/json",
        Description = "Успех.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound, "application/problem+json",
        Description = "Просмотренные пользователем мероприятия найдены.")]
    public async Task<IActionResult> GetRecentViewedEventsAsync(Guid id, CancellationToken cancellationToken)
    {
        var events = await mediator.Send(new GetRecentViewedEventsQuery(id), cancellationToken);

        return Ok(events);
    }
}