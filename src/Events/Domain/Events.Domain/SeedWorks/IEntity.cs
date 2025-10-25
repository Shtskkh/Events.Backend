namespace Events.Domain.SeedWorks;

/// <summary>
///     Интерфейс сущности.
/// </summary>
/// <typeparam name="TKey">Тип данных идентификатора сущности.</typeparam>
public interface IEntity<TKey>
{
    /// <summary>
    ///     Идентификатор сущности.
    /// </summary>
    TKey Id { get; set; }
}