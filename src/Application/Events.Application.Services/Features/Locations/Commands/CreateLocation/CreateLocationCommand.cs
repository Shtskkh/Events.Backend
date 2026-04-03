using Events.Contracts.Locations;
using MediatR;

namespace Events.Application.Services.Features.Locations.Commands.CreateLocation;

/// <summary>
///     Команда создания локации.
/// </summary>
/// <param name="Dto">Модель создания локации.</param>
public record CreateLocationCommand(CreateLocationDto Dto) : IRequest<int>;