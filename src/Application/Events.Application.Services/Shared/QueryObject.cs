namespace Events.Application.Services.Shared;

/// <summary>
///     Класс-обёртка над Func, позволяющая удобно описывать сложные запросы (с GroupBy, Count, Sum и т.д.).
/// </summary>
/// <typeparam name="TEntity">Тип сущности.</typeparam>
/// <typeparam name="TResult">Тип результата после проекции.</typeparam>
public sealed class QueryObject<TEntity, TResult>
    where TEntity : class
{
    public QueryObject(Func<IQueryable<TEntity>, IQueryable<TResult>> build)
    {
        Build = build ?? throw new ArgumentNullException(nameof(build));
    }

    public Func<IQueryable<TEntity>, IQueryable<TResult>> Build { get; }

    public static implicit operator Func<IQueryable<TEntity>, IQueryable<TResult>>(
        QueryObject<TEntity, TResult> queryObject)
    {
        return queryObject.Build;
    }
}