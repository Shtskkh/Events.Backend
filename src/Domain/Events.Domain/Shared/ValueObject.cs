namespace Events.Domain.Shared;

/// <summary>
/// Абстрактный класс value objects.
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

	public static bool operator ==(ValueObject? left, ValueObject? right)
	{
		return Equals(left, right);
	}

	public static bool operator !=(ValueObject? left, ValueObject? right)
	{
		return !Equals(left, right);
	}
}