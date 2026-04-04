using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetPlaceholders;

/// <summary>
///     Запрос на получение всех плейсхолдеров
/// </summary>
public record GetEventsPlaceholdersQuery : IRequest<IReadOnlyCollection<string>>;