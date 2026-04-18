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
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Guid))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDto))]
    public async Task<IActionResult> CreateAsync([FromForm] CreateUserDto createUserDto, CancellationToken ct)
    {
        var id = await mediator.Send(new CreateUserCommand(createUserDto), ct);
        return StatusCode(StatusCodes.Status201Created, id);
    }

    /// <summary>
    ///     Аутентифицировать пользователя.
    /// </summary>
    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TokenDto))]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(ErrorDto))]
    public async Task<IActionResult> AuthAsync([FromForm] AuthDto dto, CancellationToken cancellationToken)
    {
        var tokenDto = await mediator.Send(new AuthUserCommand(dto), cancellationToken);

        return Ok(tokenDto);
    }

    /// <summary>
    ///     Получить всех пользователей, удовлетворяющих фильтру.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyCollection<ShortUserDto>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    public async Task<IActionResult> GetByFilterAsync([FromQuery] UserFilterDto userFilterDto, CancellationToken ct)
    {
        var result = await mediator.Send(new GetUsersByFilter(userFilterDto), ct);
        return Ok(result);
    }

    /// <summary>
    ///     Получить пользователя по ID.
    /// </summary>
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
    [HttpGet("{userId:guid}/events/recent")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyCollection<ShortEventDto>))]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound,
        Description = "Просмотренные пользователем мероприятия найдены.")]
    public async Task<IActionResult> GetRecentViewedEventsAsync(Guid userId, CancellationToken ct)
    {
        var events = await mediator.Send(new GetRecentViewedEventsQuery(userId), ct);
        return Ok(events);
    }

    [HttpPatch("{userId:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid userId, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///     Изменить пароль.
    /// </summary>
    [HttpPatch("{userId:guid}/password")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDto))]
    public async Task<IActionResult> ChangePassword(Guid userId, [FromForm] ChangePasswordDto changePasswordDto,
        CancellationToken ct)
    {
        await mediator.Send(new ChangePasswordCommand(userId, changePasswordDto), ct);
        return Ok();
    }

    /// <summary>
    ///     Удалить пользователя.
    /// </summary>
    [HttpDelete("{userId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    public async Task<IActionResult> DeleteAsync(Guid userId, CancellationToken ct)
    {
        await mediator.Send(new DeleteUserCommand(userId), ct);
        return Ok();
    }
}