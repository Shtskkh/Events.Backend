using Events.Contracts.Features.Locations.Places;
using MediatR;

namespace Events.Application.Services.Features.Locations.Commands.CreatePlace;

/// <summary>
///     Команда создания помещения.
/// </summary>
/// <param name="LocationId">
///     ID локации, в которой создаётся помещение.
/// </param>
/// <param name="Dto">
///     Модель создания помещения.
/// </param>
public record CreatePlaceCommand(
    int LocationId,
    CreatePlaceDto Dto
) : IRequest<int>;