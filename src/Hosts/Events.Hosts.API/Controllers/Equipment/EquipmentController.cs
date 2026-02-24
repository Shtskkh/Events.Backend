using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Events.Hosts.API.Controllers.Equipment;

[ApiController]
[Route("/api/v/1/[controller]")]
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
}