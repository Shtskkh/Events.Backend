using Events.Contracts.Features.Events.DTOs;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetAllEventsPlaceholders;

/// <summary>
///     Запрос на получение всех плейсхолдеров
/// </summary>
public record GetAllEventsPlaceholdersQuery : IRequest<IReadOnlyCollection<EventPlaceholderDto>>;