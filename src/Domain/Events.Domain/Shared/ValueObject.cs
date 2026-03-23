namespace Events.Domain.Shared;

/// <summary>
///     Абстрактный класс объекта-значения.
/// </summary>
public abstract class ValueObject : IEquatable<ValueObject>
{
    /// <inheritdoc />
    public bool Equals(ValueObject? other)
    {
        if (other is null)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        if (GetType() != other.GetType())
            return false;

        return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    /// <summary>
    ///     Метод получения параметров для сравнения.
    /// </summary>
    /// <returns>
    ///     Объекты для сравнения через yield.
    /// </returns>
    protected abstract IEnumerable<object?> GetEqualityComponents();

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        return obj is ValueObject valueObject && Equals(valueObject);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        var hash = new HashCode();

        foreach (var component in GetEqualityComponents())
            hash.Add(component);

        return hash.ToHashCode();
    }

    /// <summary>
    ///     Оператор проверки равенства объектов.
    /// </summary>
    /// <param name="left">Левый операнд.</param>
    /// <param name="right">Правый операнд.</param>
    /// <returns>
    ///     True, если объекты равны, false иначе.
    /// </returns>
    public static bool operator ==(ValueObject? left, ValueObject? right)
    {
        return left?.Equals(right) ?? right is null;
    }

    /// <summary>
    ///     Оператор проверки неравенства объектов.
    /// </summary>
    /// <param name="left">Левый операнд.</param>
    /// <param name="right">Правый операнд.</param>
    /// <returns>
    ///     True, если объекты неравны, false иначе.
    /// </returns>
    public static bool operator !=(ValueObject? left, ValueObject? right)
    {
        return !(left == right);
    }
}