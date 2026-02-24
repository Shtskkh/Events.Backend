using Events.Contracts.Errors;
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
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync()
    {
        throw new NotImplementedException();
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

    [HttpPost("{locationId:int}/places")]
    public async Task<IActionResult> CreatePlaceAsync(int locationId)
    {
        throw new NotImplementedException();
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