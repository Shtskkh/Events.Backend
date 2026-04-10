namespace Events.Application.Services.Shared;

/// <summary>
///     Делегат для построения типизированного запроса к хранилищу.
///     Принимает базовый <see cref="IQueryable{T}" /> сущности и возвращает
///     трансформированный запрос, не материализуя его —
///     материализация происходит на стороне репозитория.
/// </summary>
/// <typeparam name="TEntity">Тип сущности в хранилище.</typeparam>
/// <typeparam name="TResult">Тип результата после проекции.</typeparam>
/// <param name="query">Базовый запрос к хранилищу.</param>
/// <returns>Трансформированный запрос.</returns>
public delegate IQueryable<TResult> QueryObject<in TEntity, out TResult>(IQueryable<TEntity> query);