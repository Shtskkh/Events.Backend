namespace Events.Domain.Shared;

/// <summary>
/// Абстрактный класс сущностей.
/// </summary>
/// <param name="id">Идентификатор.</param>
/// <typeparam name="TKey">Тип идентификатора.</typeparam>
public abstract class Entity<TKey>(TKey id)
	where TKey : IEquatable<TKey>
{
	public TKey Id => id;

	public override bool Equals(object? obj)
	{
		if (obj is not Entity<TKey> other) return false;
		if (ReferenceEquals(this, other)) return true;
		if (GetType() != other.GetType()) return false;
		if (Id.Equals(default) || other.Id.Equals(default)) return false;

		return Id.Equals(other.Id);
	}

	public override int GetHashCode() => id.GetHashCode();

	public static bool operator ==(Entity<TKey>? left, Entity<TKey>? right)
	{
		return Equals(left, right);
	}

	public static bool operator !=(Entity<TKey>? left, Entity<TKey>? right)
	{
		return !Equals(left, right);
	}

	/// <summary>
	/// Проверка на присвоение сущности идентификатора.
	/// </summary>
	/// <returns>
	/// True, если сущности присвоен
	/// идентификатор, false иначе.
	/// </returns>
	public bool IsTransient()
	{
		return Id.Equals(default);
	}
}