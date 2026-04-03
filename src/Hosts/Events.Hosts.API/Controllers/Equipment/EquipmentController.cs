using Events.Application.Services.Features.Equipment.Commands.Create;
using Events.Application.Services.Features.Equipment.Commands.Delete;
using Events.Application.Services.Features.Equipment.Queries.GetByFilter;
using Events.Application.Services.Features.Equipment.Queries.GetTypes;
using Events.Contracts.Equipment;
using Events.Contracts.Equipment.EquipmentTypes;
using Events.Contracts.Errors;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Events.Hosts.API.Controllers.Equipment;

[ApiController]
[Route("/api/v/1/[controller]")]
[ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError, "application/problem+json",
    Description = "Неожиданная ошибка сервера.")]
public class EquipmentController(IMediator mediator) : ControllerBase
{
    /// <summary>
    ///     Получить оборудование по фильтру.
    /// </summary>
    /// <param name="filter">Фильтр.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекция оборудования.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<EquipmentDto>), StatusCodes.Status201Created, "text/plain",
        Description = "Оборудование создано.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest, "application/problem+json",
        Description = "Неправильный запрос.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound, "application/problem+json",
        Description = "Оборудование по фильтру не найдено.")]
    public async Task<IActionResult> GetByFilterAsync([FromQuery] EquipmentFilterDto filter,
        CancellationToken cancellationToken)
    {
        var equipment = await mediator.Send(new GetEquipmentByFilterQuery(filter), cancellationToken);

        return Ok(equipment);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///     Создать оборудование.
    /// </summary>
    /// <param name="dto">Модель создания оборудования.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>ID созданного оборудования.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created, "text/plain",
        Description = "Оборудование создано.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest, "application/problem+json",
        Description = "Неправильный запрос.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound, "application/problem+json",
        Description = "Представленные данные в запросе не найдены.")]
    public async Task<IActionResult> CreateAsync([FromForm] CreateEquipmentDto dto, CancellationToken cancellationToken)
    {
        var id = await mediator.Send(new CreateEquipmentCommand(dto), cancellationToken);

        return StatusCode(StatusCodes.Status201Created, id);
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> UpdateAsync(int id)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///     Удалить оборудование.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Description = "Оборудование удалено.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound, "application/problem+json",
        Description = "Оборудование не найдено.")]
    public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteEquipmentCommand(id), cancellationToken);

        return Ok();
    }

    /// <summary>
    ///     Получить все типы оборудования.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекция типов.</returns>
    [HttpGet("types")]
    [ProducesResponseType(typeof(IReadOnlyCollection<EquipmentTypeDto>), StatusCodes.Status200OK, "application/json",
        Description = "Успех.")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound, "application/problem+json",
        Description = "Типы оборудования не найдены.")]
    public async Task<IActionResult> GetTypes(CancellationToken cancellationToken)
    {
        var types = await mediator.Send(new GetEquipmentTypesQuery(), cancellationToken);

        return Ok(types);
    }
}