using Events.Application.Services.Features.Locations.Commands.CreateLocation;
using Events.Application.Services.Features.Locations.Commands.CreatePlace;
using Events.Application.Services.Features.Locations.Queries.GetAllLocationsQuery;
using Events.Application.Services.Features.Locations.Queries.GetAllPlacesTypes;
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
    /// <returns>Коллекция локаций.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<ShortLocationDto>), StatusCodes.Status200OK, "application/json",
        Description = "Успех.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound, "application/problem+json",
        Description = "Локации не найдены.")]
    public async Task<IActionResult> GetAllAsync()
    {
        var locations = await mediator.Send(new GetAllLocationsQuery());

        return Ok(locations);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///     Создать локацию.
    /// </summary>
    /// <param name="dto">Форма создания локации.</param>
    /// <returns>ID созданной локации.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created, "text/plain",
        Description = "Локация создана.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest, "application/problem+json",
        Description = "Неправильный запрос.")]
    public async Task<IActionResult> CreateAsync([FromForm] CreateLocationDto dto)
    {
        var id = await mediator.Send(new CreateLocationCommand(dto));

        return StatusCode(StatusCodes.Status201Created, id);
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> UpdateAsync(int id)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    [HttpGet("{locationId:int}/places")]
    public async Task<IActionResult> GetAllPlaces(int locationId)
    {
        throw new NotImplementedException();
    }

    [HttpGet("{locationId:int}/places/{placeId:int}")]
    public async Task<IActionResult> GetPlaceById(int locationId, int placeId)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///     Создать помещение в локации.
    /// </summary>
    /// <param name="locationId">ID локации.</param>
    /// <param name="dto">Модель создания помещения.</param>
    /// <returns>ID созданного помещения.</returns>
    [HttpPost("{locationId:int}/places")]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created, "text/plain",
        Description = "Помещение создано.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound, "application/problem+json",
        Description = "Представленные в запросе данные не найдены.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest, "application/problem+json",
        Description = "Неправильный запрос.")]
    public async Task<IActionResult> CreatePlaceAsync([FromRoute] int locationId, [FromForm] CreatePlaceDto dto)
    {
        var id = await mediator.Send(new CreatePlaceCommand(locationId, dto));

        return StatusCode(StatusCodes.Status201Created, id);
    }

    [HttpPatch("{locationId:int}/places/{placeId:int}")]
    public async Task<IActionResult> UpdatePlaceAsync(int locationId, int placeId)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{locationId:int}/places/{placeId:int}")]
    public async Task<IActionResult> DeletePlaceAsync(int locationId, int placeId)
    {
        throw new NotImplementedException();
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
    public async Task<IActionResult> GetAllPlacesTypes()
    {
        var dtos = await mediator.Send(new GetAllPlacesTypesQuery());

        return Ok(dtos);
    }

    [HttpGet("{locationId:int}/places/{placeId:int}/equipment")]
    public async Task<IActionResult> GetPlaceEquipment(int locationId, int placeId)
    {
        throw new NotImplementedException();
    }

    [HttpPost("{locationId:int}/places/{placeId:int}/equipment")]
    public async Task<IActionResult> CreatePlaceEquipment(int locationId, int placeId)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{locationId:int}/places/{placeId:int}/equipment/{equipmentId:int}")]
    public async Task<IActionResult> DeletePlaceEquipment(int locationId, int placeId, int equipmentId)
    {
        throw new NotImplementedException();
    }
}