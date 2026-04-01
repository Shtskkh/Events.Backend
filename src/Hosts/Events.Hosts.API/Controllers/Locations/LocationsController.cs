using Events.Application.Services.Features.Locations.Commands.CreateLocation;
using Events.Application.Services.Features.Locations.Commands.CreatePlace;
using Events.Application.Services.Features.Locations.Commands.DeleteLocation;
using Events.Application.Services.Features.Locations.Commands.DeletePlace;
using Events.Application.Services.Features.Locations.Commands.UpdateLocation;
using Events.Application.Services.Features.Locations.Commands.UpdatePlace;
using Events.Application.Services.Features.Locations.Queries.GetAllLocationsQuery;
using Events.Application.Services.Features.Locations.Queries.GetAllPlacesTypes;
using Events.Application.Services.Features.Locations.Queries.GetAvailablePlaces;
using Events.Application.Services.Features.Locations.Queries.GetLocationById;
using Events.Application.Services.Features.Locations.Queries.GetLocationPlaces;
using Events.Application.Services.Features.Locations.Queries.GetPlaceById;
using Events.Contracts.Errors;
using Events.Contracts.Features.Locations.DTOs;
using Events.Contracts.Features.Locations.Places;
using Events.Contracts.Features.Locations.PlacesTypes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Events.Hosts.API.Controllers.Locations;

/// <summary>
///     Контроллер локаций.
/// </summary>
/// <param name="mediator">Медиатор.</param>
[ApiController]
[Route("api/v/1/[controller]")]
[ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError, "application/problem+json",
    Description = "Неожиданная ошибка сервера.")]
public class LocationsController(IMediator mediator) : ControllerBase
{
    /// <summary>
    ///     Получить все локации.
    /// </summary>
    /// <param name="cancellationToken">Токен отмен.</param>
    /// <returns>Коллекция локаций.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<ShortLocationDto>), StatusCodes.Status200OK, "application/json",
        Description = "Успех.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound, "application/problem+json",
        Description = "Локации не найдены.")]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        var locations = await mediator.Send(new GetAllLocationsQuery(), cancellationToken);

        return Ok(locations);
    }

    /// <summary>
    ///     Получить локацию по ID.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Локация.</returns>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(LocationDto), StatusCodes.Status200OK, "application/json",
        Description = "Успех.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound, "application/problem+json",
        Description = "Локация не найдена.")]
    public async Task<IActionResult> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var location = await mediator.Send(new GetLocationByIdQuery(id), cancellationToken);

        return Ok(location);
    }

    /// <summary>
    ///     Создать локацию.
    /// </summary>
    /// <param name="dto">Форма создания локации.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>ID созданной локации.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created, "text/plain",
        Description = "Локация создана.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest, "application/problem+json",
        Description = "Неправильный запрос.")]
    public async Task<IActionResult> CreateAsync([FromForm] CreateLocationDto dto, CancellationToken cancellationToken)
    {
        var id = await mediator.Send(new CreateLocationCommand(dto), cancellationToken);

        return StatusCode(StatusCodes.Status201Created, id);
    }

    /// <summary>
    ///     Обновить локацию.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="updateDto">Модель обновления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    [HttpPatch("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Description = "Успех.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest, "application/problem+json",
        Description = "Неправильный запрос.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound, "application/problem+json",
        Description = "Локация не найдена.")]
    public async Task<IActionResult> UpdateAsync(int id, [FromForm] UpdateLocationDto updateDto,
        CancellationToken cancellationToken)
    {
        await mediator.Send(new UpdateLocationCommand(id, updateDto), cancellationToken);

        return Ok();
    }

    /// <summary>
    ///     Удалить локацию.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Description = "Успех.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound, "application/problem+json",
        Description = "Локация не найдена.")]
    public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteLocationCommand(id), cancellationToken);

        return Ok();
    }

    /// <summary>
    ///     Получить все помещения в локации.
    /// </summary>
    /// <param name="locationId">Идентификатор локации.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекция помещений.</returns>
    [HttpGet("{locationId:int}/places")]
    [ProducesResponseType(typeof(IReadOnlyList<ShortPlaceDto>), StatusCodes.Status200OK, "application/json",
        Description = "Успех.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound, "application/problem+json",
        Description = "Помещения не найдены.")]
    public async Task<IActionResult> GetAllPlaces(int locationId, CancellationToken cancellationToken)
    {
        var places = await mediator.Send(new GetLocationPlacesQuery(locationId), cancellationToken);

        return Ok(places);
    }

    /// <summary>
    ///     Получить доступные для бронирования помещения.
    /// </summary>
    /// <param name="locationId">Идентификатор локации.</param>
    /// <param name="start">Желаемая дата начала бронирования.</param>
    /// <param name="end">Желаемая дата окончания бронирования.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекция помещений с флагом доступности.</returns>
    [HttpGet("{locationId:int}/places/availability")]
    [ProducesResponseType(typeof(IReadOnlyCollection<PlaceAvailabilityDto>), StatusCodes.Status200OK,
        "application/json",
        Description = "Успех.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound, "application/problem+json",
        Description = "Локация не найдена.")]
    public async Task<IActionResult> GetPlacesAvailability(
        [FromRoute] int locationId,
        [FromQuery] DateTimeOffset start,
        [FromQuery] DateTimeOffset end,
        CancellationToken cancellationToken
    )
    {
        var places = await mediator.Send(new GetAvailablePlacesQuery(locationId, start, end), cancellationToken);

        return Ok(places);
    }

    /// <summary>
    ///     Получить помещение по ID.
    /// </summary>
    /// <param name="locationId">Идентификатор локации.</param>
    /// <param name="placeId">Идентификатор помещения.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Помещение.</returns>
    [HttpGet("{locationId:int}/places/{placeId:int}")]
    [ProducesResponseType(typeof(PlaceDto), StatusCodes.Status200OK, "application/json",
        Description = "Успех.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound, "application/problem+json",
        Description = "Локация или помещение не найдено.")]
    public async Task<IActionResult> GetPlaceById(int locationId, int placeId, CancellationToken cancellationToken)
    {
        var place = await mediator.Send(new GetPlaceByIdQuery(locationId, placeId), cancellationToken);

        return Ok(place);
    }

    /// <summary>
    ///     Создать помещение в локации.
    /// </summary>
    /// <param name="locationId">ID локации.</param>
    /// <param name="dto">Модель создания помещения.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>ID созданного помещения.</returns>
    [HttpPost("{locationId:int}/places")]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created, "text/plain",
        Description = "Помещение создано.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest, "application/problem+json",
        Description = "Неправильный запрос.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound, "application/problem+json",
        Description = "Представленные в запросе данные не найдены.")]
    public async Task<IActionResult> CreatePlaceAsync([FromRoute] int locationId, [FromForm] CreatePlaceDto dto,
        CancellationToken cancellationToken)
    {
        var id = await mediator.Send(new CreatePlaceCommand(locationId, dto), cancellationToken);

        return StatusCode(StatusCodes.Status201Created, id);
    }

    /// <summary>
    ///     Обновить помещение.
    /// </summary>
    /// <param name="locationId">Идентификатор локации.</param>
    /// <param name="placeId">Идентификатор помещения.</param>
    /// <param name="updateDto">Модель обновления помещения.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    [HttpPatch("{locationId:int}/places/{placeId:int}")]
    [ProducesResponseType(typeof(PlaceDto), StatusCodes.Status200OK, "application/json",
        Description = "Успех.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest, "application/problem+json",
        Description = "Неправильный запрос.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound, "application/problem+json",
        Description = "Локация, помещение или тип помещения не найдены.")]
    public async Task<IActionResult> UpdatePlaceAsync(int locationId, int placeId, [FromForm] UpdatePlaceDto updateDto,
        CancellationToken cancellationToken)
    {
        await mediator.Send(new UpdatePlaceCommand(locationId, placeId, updateDto), cancellationToken);

        return Ok();
    }

    /// <summary>
    ///     Удалить помещение.
    /// </summary>
    /// <param name="locationId">Идентификатор локации.</param>
    /// <param name="placeId">Идентификатор помещения.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    [HttpDelete("{locationId:int}/places/{placeId:int}")]
    [ProducesResponseType(typeof(PlaceDto), StatusCodes.Status200OK, "application/json",
        Description = "Успех.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound, "application/problem+json",
        Description = "Локация или помещение не найдено.")]
    public async Task<IActionResult> DeletePlaceAsync(int locationId, int placeId, CancellationToken cancellationToken)
    {
        await mediator.Send(new DeletePlaceCommand(locationId, placeId), cancellationToken);

        return Ok();
    }

    /// <summary>
    ///     Получить все типы помещений.
    /// </summary>
    /// <returns>
    ///     Коллекций типов помещений.
    /// </returns>
    [HttpGet("places/types")]
    [ProducesResponseType(typeof(IReadOnlyCollection<PlaceTypeDto>), StatusCodes.Status200OK, "application/json",
        Description = "Успех.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound, "application/problem+json",
        Description = "Типы помещений не найдены.")]
    public async Task<IActionResult> GetAllPlacesTypes(CancellationToken cancellationToken)
    {
        var types = await mediator.Send(new GetAllPlacesTypesQuery(), cancellationToken);

        return Ok(types);
    }
}