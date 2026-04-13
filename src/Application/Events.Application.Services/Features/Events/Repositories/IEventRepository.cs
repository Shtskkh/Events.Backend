using Ardalis.Specification;
using Events.Application.Services.Shared;
using Events.Domain.Aggregates.EventAggregate;

namespace Events.Application.Services.Features.Events.Repositories;

public interface IEventRepository : IRepository<Event>
{
    /// <summary>
    ///     Получить мероприятия, удовлетворяющие фильтру.
    /// </summary>
    /// <param name="spec">Спецификация фильтра.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <param name="textQuery">Запрос текстового поиска.</param>
    /// <returns>Коллекция мероприятий.</returns>
    Task<List<Event>> ListAsync(
        ISpecification<Event> spec,
        CancellationToken cancellationToken = default,
        string? textQuery = null
    );
}