using Events.Application.Services.Features.Locations.Commands.Create;
using Events.Application.Services.Features.Locations.Commands.Delete;
using Events.Application.Services.Features.Locations.Commands.Update;
using Events.Application.Services.Features.Locations.Queries.GetAll;
using Events.Application.Services.Features.Locations.Queries.GetAvailablePlaces;
using Events.Application.Services.Features.Locations.Queries.GetById;
using Events.Application.Services.Features.Locations.Queries.GetPlaces;
using Events.Application.Services.Features.Places.Commands.Create;
using Events.Application.Services.Features.Places.Commands.Delete;
using Events.Application.Services.Features.Places.Commands.Update;
using Events.Application.Services.Features.Places.Queries.GetById;
using Events.Application.Services.Features.Places.Queries.GetTypes;
using Events.Contracts.Errors;
using Events.Contracts.Locations;
using Events.Contracts.Places;
using Events.Contracts.Places.PlacesTypes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Events.Hosts.API.Controllers;

[ApiController]
[Route("api/v/1/[controller]")]
[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDto))]
public class LocationsController(IMediator mediator) : ControllerBase
{
    /// <summary>
    ///     Создать локацию.
    /// </summary>
    /// <param name="createLocationDto">Форма создания локации.</param>
    /// <param name="ct">Токен отмены.</param>
    /// <returns>Идентификатор созданной локации.</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(int))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDto))]
    public async Task<IActionResult> CreateAsync([FromForm] CreateLocationDto createLocationDto, CancellationToken ct)
    {
        var locationId = await mediator.Send(new CreateLocationCommand(createLocationDto), ct);
        return StatusCode(StatusCodes.Status201Created, locationId);
    }

    /// <summary>
    ///     Получить все локации.
    /// </summary>
    /// <param name="ct">Токен отмены.</param>
    /// <returns>Коллекция локаций.</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyCollection<ShortLocationDto>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    public async Task<IActionResult> GetAllAsync(CancellationToken ct)
    {
        var locations = await mediator.Send(new GetLocationsQuery(), ct);
        return Ok(locations);
    }

    /// <summary>
    ///     Получить локацию по ID.
    /// </summary>
    /// <param name="locationId">Идентификатор локации.</param>
    /// <param name="ct">Токен отмены.</param>
    /// <returns>Полная информация о локации.</returns>
    [HttpGet("{locationId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LocationDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    public async Task<IActionResult> GetByIdAsync(int locationId, CancellationToken ct)
    {
        var location = await mediator.Send(new GetLocationByIdQuery(locationId), ct);
        return Ok(location);
    }

    /// <summary>
    ///     Обновить локацию.
    /// </summary>
    /// <param name="locationId">Идентификатор локации.</param>
    /// <param name="dto">Форма обновления локации.</param>
    /// <param name="ct">Токен отмены.</param>
    [HttpPatch("{locationId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDto))]
    public async Task<IActionResult> UpdateAsync(int locationId, [FromForm] UpdateLocationDto dto, CancellationToken ct)
    {
        await mediator.Send(new UpdateLocationCommand(locationId, dto), ct);
        return Ok();
    }

    /// <summary>
    ///     Удалить локацию.
    /// </summary>
    /// <param name="locationId">Идентификатор локации.</param>
    /// <param name="ct">Токен отмены.</param>
    [HttpDelete("{locationId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    public async Task<IActionResult> DeleteAsync(int locationId, CancellationToken ct)
    {
        await mediator.Send(new DeleteLocationCommand(locationId), ct);
        return Ok();
    }

    /// <summary>
    ///     Создать помещение в локации.
    /// </summary>
    /// <param name="locationId">Идентификатор локации.</param>
    /// <param name="dto">Форма создания помещения.</param>
    /// <param name="ct">Токен отмены.</param>
    /// <returns>Идентификатор созданного помещения.</returns>
    [HttpPost("{locationId:int}/places")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(int))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDto))]
    public async Task<IActionResult> CreatePlaceAsync([FromRoute] int locationId, [FromForm] CreatePlaceDto dto,
        CancellationToken ct)
    {
        var placeId = await mediator.Send(new CreatePlaceCommand(locationId, dto), ct);
        return StatusCode(StatusCodes.Status201Created, placeId);
    }

    /// <summary>
    ///     Получить все помещения в локации.
    /// </summary>
    /// <param name="locationId">Идентификатор локации.</param>
    /// <param name="ct">Токен отмены.</param>
    /// <returns>Коллекция помещений локации.</returns>
    [HttpGet("{locationId:int}/places")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<ShortPlaceDto>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    public async Task<IActionResult> GetAllPlacesAsync(int locationId, CancellationToken ct)
    {
        var places = await mediator.Send(new GetLocationPlacesQuery(locationId), ct);
        return Ok(places);
    }

    /// <summary>
    ///     Получить доступные для бронирования помещения.
    /// </summary>
    /// <param name="locationId">Идентификатор локации.</param>
    /// <param name="start">Начало запрашиваемого периода.</param>
    /// <param name="end">Окончание запрашиваемого периода.</param>
    /// <param name="ct">Токен отмены.</param>
    /// <returns>Коллекция помещений с информацией о доступности.</returns>
    [HttpGet("{locationId:int}/places/availability")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyCollection<PlaceAvailabilityDto>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    public async Task<IActionResult> GetPlacesAvailabilityAsync(
        [FromRoute] int locationId,
        [FromQuery] DateTimeOffset start,
        [FromQuery] DateTimeOffset end,
        CancellationToken ct)
    {
        var places = await mediator.Send(new GetAvailablePlacesQuery(locationId, start, end), ct);
        return Ok(places);
    }

    /// <summary>
    ///     Получить помещение по ID.
    /// </summary>
    /// <param name="locationId">Идентификатор локации.</param>
    /// <param name="placeId">Идентификатор помещения.</param>
    /// <param name="ct">Токен отмены.</param>
    /// <returns>Полная информация о помещении.</returns>
    [HttpGet("{locationId:int}/places/{placeId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PlaceDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    public async Task<IActionResult> GetPlaceByIdAsync(int locationId, int placeId, CancellationToken ct)
    {
        var place = await mediator.Send(new GetPlaceByIdQuery(placeId), ct);
        return Ok(place);
    }

    /// <summary>
    ///     Обновить помещение.
    /// </summary>
    /// <param name="locationId">Идентификатор локации.</param>
    /// <param name="placeId">Идентификатор помещения.</param>
    /// <param name="dto">Форма обновления помещения.</param>
    /// <param name="ct">Токен отмены.</param>
    [HttpPatch("{locationId:int}/places/{placeId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDto))]
    public async Task<IActionResult> UpdatePlaceAsync(int locationId, int placeId, [FromForm] UpdatePlaceDto dto,
        CancellationToken ct)
    {
        await mediator.Send(new UpdatePlaceCommand(placeId, dto), ct);
        return Ok();
    }

    /// <summary>
    ///     Удалить помещение.
    /// </summary>
    /// <param name="locationId">Идентификатор локации.</param>
    /// <param name="placeId">Идентификатор помещения.</param>
    /// <param name="ct">Токен отмены.</param>
    [HttpDelete("{locationId:int}/places/{placeId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    public async Task<IActionResult> DeletePlaceAsync(int locationId, int placeId, CancellationToken ct)
    {
        await mediator.Send(new DeletePlaceCommand(locationId, placeId), ct);
        return Ok();
    }

    /// <summary>
    ///     Получить все типы помещений.
    /// </summary>
    /// <param name="ct">Токен отмены.</param>
    /// <returns>Коллекция типов помещений.</returns>
    [HttpGet("places/types")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyCollection<PlaceTypeDto>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    public async Task<IActionResult> GetAllPlacesTypesAsync(CancellationToken ct)
    {
        var types = await mediator.Send(new GetPlacesTypesQuery(), ct);
        return Ok(types);
    }
}