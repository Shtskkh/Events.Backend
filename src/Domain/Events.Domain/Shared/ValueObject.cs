namespace Events.Domain.Shared;

/// <summary>
///     Абстрактный класс объекта-значения.
/// </summary>
public abstract class ValueObject
{
    /// <summary>
    ///     Метод получения параметров для сравнения.
    /// </summary>
    /// <returns>
    ///     Объекты для сравнения через yield.
    /// </returns>
    protected abstract IEnumerable<object> GetEqualityComponents();

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        if (obj == null || obj.GetType() != GetType()) return false;
        if (ReferenceEquals(this, obj)) return true;

        var other = (ValueObject)obj;

        return GetEqualityComponents()
            .SequenceEqual(other.GetEqualityComponents());
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Select(component => component != null ? component.GetHashCode() : 0)
            .Aggregate((x, y) => x ^ y);
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
        return Equals(left, right);
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
        return !Equals(left, right);
    }
}