using Events.Domain.Shared.Extensions;

namespace Events.Domain.Shared;

/// <summary>
/// Абстрактный класс сущности.
/// </summary>
/// <typeparam name="TKey">Тип идентификатора.</typeparam>
public abstract class Entity<TKey>
    where TKey : IEquatable<TKey>
{
    /// <summary>
    /// Идентификатор сущности.
    /// </summary>
    public TKey Id { get; }

    /// <summary>
    /// Дата и время создания сущности.
    /// </summary>
    public readonly DateTimeOffset CreatedAt;

    /// <summary>
    /// Дата и время обновления сущности.
    /// </summary>
    public DateTimeOffset UpdatedAt;

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    protected Entity(TKey id)
    {
        Id = id;
        CreatedAt = DateTimeOffset.UtcNowWithServerOffset();
        UpdatedAt = DateTimeOffset.UtcNowWithServerOffset();
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Entity<TKey> other) return false;
        if (ReferenceEquals(this, other)) return true;
        if (GetType() != other.GetType()) return false;
        if (Id.Equals(default) || other.Id.Equals(default)) return false;

        return Id.Equals(other.Id);
    }

    public override int GetHashCode() => Id.GetHashCode();

    /// <summary>
    /// Проверка равенства сущностей.
    /// </summary>
    /// <param name="left">Левый операнд.</param>
    /// <param name="right">Правый операнд.</param>
    /// <returns>True, если это одна и та же сущность, false иначе.</returns>
    public static bool operator ==(Entity<TKey>? left, Entity<TKey>? right)
    {
        return Equals(left, right);
    }

    /// <summary>
    /// Проверка неравенства сущностей.
    /// </summary>
    /// <param name="left">Левый операнд.</param>
    /// <param name="right">Правый операнд.</param>
    /// <returns>True, если сущности разные, false иначе.</returns>
    public static bool operator !=(Entity<TKey>? left, Entity<TKey>? right)
    {
        return !Equals(left, right);
    }

    /// <summary>
    /// Проверка на присвоение сущности идентификатора.
    /// </summary>
    /// <returns>
    /// True, если сущности присвоен идентификатор, false иначе.
    /// </returns>
    public bool IsTransient()
    {
        return Id.Equals(default);
    }
}