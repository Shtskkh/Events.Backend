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

[ApiController]
[Route("api/v/1/[controller]")]
[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDto))]
public class UsersController(IMediator mediator) : ControllerBase
{
    /// <summary>
    ///     Создать пользователя.
    /// </summary>
    /// <param name="createUserDto">Форма создания пользователя.</param>
    /// <param name="ct">Токен отмены.</param>
    /// <returns>UUID созданного пользователя.</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Guid))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDto))]
    public async Task<IActionResult> CreateAsync([FromForm] CreateUserDto createUserDto, CancellationToken ct)
    {
        var userId = await mediator.Send(new CreateUserCommand(createUserDto), ct);
        return StatusCode(StatusCodes.Status201Created, userId);
    }

    /// <summary>
    ///     Аутентифицировать пользователя.
    /// </summary>
    /// <param name="dto">Форма аутентификации (логин и пароль).</param>
    /// <param name="ct">Токен отмены.</param>
    /// <returns>Токены доступа.</returns>
    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TokenDto))]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(ErrorDto))]
    public async Task<IActionResult> AuthAsync([FromForm] AuthDto dto, CancellationToken ct)
    {
        var tokenDto = await mediator.Send(new AuthUserCommand(dto), ct);
        return Ok(tokenDto);
    }

    /// <summary>
    ///     Получить пользователей по фильтру.
    /// </summary>
    /// <param name="userFilterDto">Фильтр для выборки пользователей.</param>
    /// <param name="ct">Токен отмены.</param>
    /// <returns>Коллекция пользователей.</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyCollection<ShortUserDto>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    public async Task<IActionResult> GetByFilterAsync([FromQuery] UserFilterDto userFilterDto, CancellationToken ct)
    {
        var users = await mediator.Send(new GetUsersByFilter(userFilterDto), ct);
        return Ok(users);
    }

    /// <summary>
    ///     Получить пользователя по ID.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <param name="ct">Токен отмены.</param>
    /// <returns>Полная информация о пользователе.</returns>
    [HttpGet("{userId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    public async Task<IActionResult> GetByIdAsync(Guid userId, CancellationToken ct)
    {
        var user = await mediator.Send(new GetUserByIdQuery(userId), ct);
        return Ok(user);
    }

    /// <summary>
    ///     Получить последние 10 просмотренных пользователем мероприятий.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <param name="ct">Токен отмены.</param>
    /// <returns>Коллекция из не более чем 10 мероприятий.</returns>
    [HttpGet("{userId:guid}/events/recent")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyCollection<ShortEventDto>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    public async Task<IActionResult> GetRecentViewedEventsAsync(Guid userId, CancellationToken ct)
    {
        var events = await mediator.Send(new GetRecentViewedEventsQuery(userId), ct);
        return Ok(events);
    }

    /// <summary>
    ///     Обновить пользователя.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <param name="ct">Токен отмены.</param>
    [HttpPatch("{userId:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid userId, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///     Изменить пароль пользователя.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <param name="dto">Форма смены пароля.</param>
    /// <param name="ct">Токен отмены.</param>
    [HttpPatch("{userId:guid}/password")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDto))]
    public async Task<IActionResult> ChangePasswordAsync(Guid userId, [FromForm] ChangePasswordDto dto,
        CancellationToken ct)
    {
        await mediator.Send(new ChangePasswordCommand(userId, dto), ct);
        return Ok();
    }

    /// <summary>
    ///     Удалить пользователя.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <param name="ct">Токен отмены.</param>
    [HttpDelete("{userId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    public async Task<IActionResult> DeleteAsync(Guid userId, CancellationToken ct)
    {
        await mediator.Send(new DeleteUserCommand(userId), ct);
        return Ok();
    }
}