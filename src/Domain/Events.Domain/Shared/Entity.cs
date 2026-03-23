namespace Events.Domain.Shared;

/// <summary>
///     Абстрактный класс сущности.
/// </summary>
/// <typeparam name="TKey">Тип первичного ключа.</typeparam>
public abstract class Entity<TKey> : IEquatable<Entity<TKey>>
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

    public bool Equals(Entity<TKey>? other)
    {
        if (other is null)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        if (GetType() != other.GetType())
            return false;

        if (IsTransient() || other.IsTransient())
            return false;

        return Id.Equals(other.Id);
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        return Equals(obj as Entity<TKey>);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        if (IsTransient())
            return base.GetHashCode();

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
        return left?.Equals(right) ?? right is null;
    }

    /// <summary>
    ///     Оператор проверки неравенства сущностей.
    /// </summary>
    /// <param name="left">Левый операнд.</param>
    /// <param name="right">Правый операнд.</param>
    /// <returns>
    ///     True, если сущности неравны, false иначе.
    /// </returns>
    public static bool operator !=(Entity<TKey>? left, Entity<TKey>? right)
    {
        return !(left == right);
    }

    /// <summary>
    ///     Проверка на присвоение ID.
    /// </summary>
    /// <returns>True, если ID не присвоен (равен значению по умолчанию), false если ID присвоен.</returns>
    public bool IsTransient()
    {
        return EqualityComparer<TKey>.Default.Equals(Id, default);
    }
}