namespace Events.Domain.Shared;

/// <summary>
/// Абстрактный класс value object.
/// </summary>
public abstract class ValueObject
{
    /// <summary>
    /// Получить элементы для сравнения.
    /// </summary>
    /// <returns>Последовательность элементов для сравнения.</returns>
    protected abstract IEnumerable<object> GetEqualityComponents();

    public override bool Equals(object? obj)
    {
        if (obj == null || obj.GetType() != GetType()) return false;
        if (ReferenceEquals(this, obj)) return true;

        var other = (ValueObject)obj;

        return GetEqualityComponents()
            .SequenceEqual(other.GetEqualityComponents());
    }

    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Select(component => component != null ? component.GetHashCode() : 0)
            .Aggregate((x, y) => x ^ y);
    }

    /// <summary>
    /// Проверка равенства value objects.
    /// </summary>
    /// <param name="left">Левый операнд.</param>
    /// <param name="right">Правый операнд.</param>
    /// <returns>True, если value objects равны, false иначе.</returns>
    public static bool operator ==(ValueObject? left, ValueObject? right)
    {
        return Equals(left, right);
    }

    /// <summary>
    /// Проверка неравенства value objects.
    /// </summary>
    /// <param name="left">Левый операнд.</param>
    /// <param name="right">Правый операнд.</param>
    /// <returns>True, если value objects неравны, false иначе.</returns>
    public static bool operator !=(ValueObject? left, ValueObject? right)
    {
        return !Equals(left, right);
    }
}