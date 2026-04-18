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
    [HttpPatch("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDto))]
    public async Task<IActionResult> UpdateAsync(int id, [FromForm] UpdateLocationDto updateDto,
        CancellationToken ct)
    {
        await mediator.Send(new UpdateLocationCommand(id, updateDto), ct);
        return Ok();
    }

    /// <summary>
    ///     Удалить локацию.
    /// </summary>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    public async Task<IActionResult> DeleteAsync(int id, CancellationToken ct)
    {
        await mediator.Send(new DeleteLocationCommand(id), ct);
        return Ok();
    }

    /// <summary>
    ///     Создать помещение в локации.
    /// </summary>
    [HttpPost("{locationId:int}/places")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(int))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDto))]
    public async Task<IActionResult> CreatePlaceAsync([FromRoute] int locationId, [FromForm] CreatePlaceDto dto,
        CancellationToken ct)
    {
        var id = await mediator.Send(new CreatePlaceCommand(locationId, dto), ct);
        return StatusCode(StatusCodes.Status201Created, id);
    }

    /// <summary>
    ///     Получить все помещения в локации.
    /// </summary>
    [HttpGet("{locationId:int}/places")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<ShortPlaceDto>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    public async Task<IActionResult> GetAllPlaces(int locationId, CancellationToken ct)
    {
        var places = await mediator.Send(new GetLocationPlacesQuery(locationId), ct);
        return Ok(places);
    }

    /// <summary>
    ///     Получить доступные для бронирования помещения.
    /// </summary>
    [HttpGet("{locationId:int}/places/availability")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyCollection<PlaceAvailabilityDto>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    public async Task<IActionResult> GetPlacesAvailability(
        [FromRoute] int locationId,
        [FromQuery] DateTimeOffset start,
        [FromQuery] DateTimeOffset end,
        CancellationToken ct
    )
    {
        var places = await mediator.Send(new GetAvailablePlacesQuery(locationId, start, end), ct);
        return Ok(places);
    }

    /// <summary>
    ///     Получить помещение по ID.
    /// </summary>
    [HttpGet("{locationId:int}/places/{placeId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PlaceDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    public async Task<IActionResult> GetPlaceById(int locationId, int placeId, CancellationToken ct)
    {
        var place = await mediator.Send(new GetPlaceByIdQuery(placeId), ct);
        return Ok(place);
    }

    /// <summary>
    ///     Обновить помещение.
    /// </summary>
    [HttpPatch("{locationId:int}/places/{placeId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PlaceDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDto))]
    public async Task<IActionResult> UpdatePlaceAsync(int locationId, int placeId, [FromForm] UpdatePlaceDto updateDto,
        CancellationToken ct)
    {
        await mediator.Send(new UpdatePlaceCommand(placeId, updateDto), ct);
        return Ok();
    }

    /// <summary>
    ///     Удалить помещение.
    /// </summary>
    [HttpDelete("{locationId:int}/places/{placeId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PlaceDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    public async Task<IActionResult> DeletePlaceAsync(int locationId, int placeId, CancellationToken ct)
    {
        await mediator.Send(new DeletePlaceCommand(locationId, placeId), ct);
        return Ok();
    }

    /// <summary>
    ///     Получить все типы помещений.
    /// </summary>
    [HttpGet("places/types")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyCollection<PlaceTypeDto>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    public async Task<IActionResult> GetAllPlacesTypes(CancellationToken ct)
    {
        var types = await mediator.Send(new GetPlacesTypesQuery(), ct);
        return Ok(types);
    }
}