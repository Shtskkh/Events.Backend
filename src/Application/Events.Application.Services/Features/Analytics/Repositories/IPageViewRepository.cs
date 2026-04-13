using Ardalis.Specification;
using Events.Domain.Aggregates.Analytics;

namespace Events.Application.Services.Features.Analytics.Repositories;

/// <summary>
///     Репозиторий просмотров страниц.
/// </summary>
public interface IPageViewRepository
{
    /// <summary>
    ///     Добавить просмотр.
    /// </summary>
    /// <param name="view">Просмотр.</param>
    /// <param name="ct">Токен отмены.</param>
    Task AddAsync(PageView view, CancellationToken ct);

    /// <summary>
    ///     Получить просмотры по фильтру.
    /// </summary>
    /// <param name="spec">Спецификация.</param>
    /// <param name="ct">Токен отмены.</param>
    /// <returns>Коллекция моделей просмотров.</returns>
    Task<IReadOnlyCollection<PageView>> GetByFilterAsync(Specification<PageView> spec, CancellationToken ct);
}