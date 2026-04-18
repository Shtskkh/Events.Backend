using Events.Application.Services.Features.Equipment.Commands.Create;
using Events.Application.Services.Features.Equipment.Commands.Delete;
using Events.Application.Services.Features.Equipment.Queries.GetByFilter;
using Events.Application.Services.Features.Equipment.Queries.GetTypes;
using Events.Contracts.Equipment;
using Events.Contracts.Equipment.EquipmentTypes;
using Events.Contracts.Errors;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Events.Hosts.API.Controllers;

[ApiController]
[Route("/api/v/1/[controller]")]
[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDto))]
public class EquipmentController(IMediator mediator) : ControllerBase
{
    /// <summary>
    ///     Создать оборудование.
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(int))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDto))]
    public async Task<IActionResult> CreateAsync([FromForm] CreateEquipmentDto dto, CancellationToken ct)
    {
        var equipmentId = await mediator.Send(new CreateEquipmentCommand(dto), ct);
        return StatusCode(StatusCodes.Status201Created, equipmentId);
    }

    /// <summary>
    ///     Получить оборудование по фильтру.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyCollection<EquipmentDto>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    public async Task<IActionResult> GetByFilterAsync([FromQuery] EquipmentFilterDto equipmentFilterDto,
        CancellationToken ct)
    {
        var equipment = await mediator.Send(new GetEquipmentByFilterQuery(equipmentFilterDto), ct);
        return Ok(equipment);
    }

    [HttpGet("{equipmentId:int}")]
    public async Task<IActionResult> GetByIdAsync(int equipmentId)
    {
        throw new NotImplementedException();
    }

    [HttpPatch("{equipmentId:int}")]
    public async Task<IActionResult> UpdateAsync(int equipmentId)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///     Удалить оборудование.
    /// </summary>
    [HttpDelete("{equipmentId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    public async Task<IActionResult> DeleteAsync(int equipmentId, CancellationToken ct)
    {
        await mediator.Send(new DeleteEquipmentCommand(equipmentId), ct);
        return Ok();
    }

    /// <summary>
    ///     Получить все типы оборудования.
    /// </summary>
    [HttpGet("types")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyCollection<EquipmentTypeDto>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    public async Task<IActionResult> GetTypes(CancellationToken ct)
    {
        var types = await mediator.Send(new GetEquipmentTypesQuery(), ct);
        return Ok(types);
    }
}