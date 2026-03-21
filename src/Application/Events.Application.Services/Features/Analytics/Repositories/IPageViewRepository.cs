using Events.Domain.Shared.Entities.Analytics.PagesViews;

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
}