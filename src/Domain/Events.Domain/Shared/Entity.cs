namespace Events.Domain.Shared;

/// <summary>
///     Абстрактный класс сущности.
/// </summary>
/// <typeparam name="TKey">Тип первичного ключа.</typeparam>
public abstract class Entity<TKey>
    where TKey : IEquatable<TKey>
{
    protected Entity()
    {
    }

    /// <summary>
    ///     Конструктор сущности.
    /// </summary>
    /// <param name="id">Идентификатор сущности.</param>
    protected Entity(TKey id)
    {
        Id = id;
    }

    /// <summary>
    ///     Идентификатор сущности.
    /// </summary>
    public TKey Id { get; }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        if (obj is not Entity<TKey> other) return false;
        if (ReferenceEquals(this, other)) return true;
        if (GetType() != other.GetType()) return false;
        if (Id.Equals(default) || other.Id.Equals(default)) return false;

        return Id.Equals(other.Id);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    /// <summary>
    ///     Оператор проверки равенства сущностей.
    /// </summary>
    /// <param name="left">Левый операнд.</param>
    /// <param name="right">Правый операнд.</param>
    /// <returns>
    ///     True, если сущности равны, false иначе.
    /// </returns>
    public static bool operator ==(Entity<TKey>? left, Entity<TKey>? right)
    {
        return Equals(left, right);
    }

    /// <summary>
    ///     Оператор проверки неравенства объектов.
    /// </summary>
    /// <param name="left">Левый операнд.</param>
    /// <param name="right">Правый операнд.</param>
    /// <returns>
    ///     True, если сущности неравны, false иначе.
    /// </returns>
    public static bool operator !=(Entity<TKey>? left, Entity<TKey>? right)
    {
        return !Equals(left, right);
    }
}