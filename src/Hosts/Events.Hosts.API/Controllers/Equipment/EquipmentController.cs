using Events.Application.Services.Features.Equipment.Commands.Create;
using Events.Application.Services.Features.Equipment.Queries.GetTypes;
using Events.Contracts.Errors;
using Events.Contracts.Features.Equipment;
using Events.Contracts.Features.EquipmentTypes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Events.Hosts.API.Controllers.Equipment;

[ApiController]
[Route("/api/v/1/[controller]")]
[ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError, "application/problem+json",
    Description = "Неожиданная ошибка сервера.")]
public class EquipmentController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetByFilterAsync()
    {
        throw new NotImplementedException();
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

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        throw new NotImplementedException();
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