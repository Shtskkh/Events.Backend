using Events.Contracts.Features.Events.DTOs;
using MediatR;

namespace Events.Application.Services.Features.Events.Commands.CreateEvent;

/// <summary>
///     Команда на создание мероприятия.
/// </summary>
/// <param name="Dto">Модель создания мероприятия.</param>
public record CreateEventCommand(CreateEventDto Dto) : IRequest<Guid>;