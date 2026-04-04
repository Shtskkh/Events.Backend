using Events.Contracts.Events;
using MediatR;

namespace Events.Application.Services.Features.Events.Commands.Create;

/// <summary>
///     Команда на создание мероприятия.
/// </summary>
/// <param name="Dto">Модель создания мероприятия.</param>
public sealed record CreateEventCommand(CreateEventDto Dto) : IRequest<Guid>;