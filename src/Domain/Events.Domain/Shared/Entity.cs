namespace Events.Domain.Shared;

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

	public bool IsTransient()
	{
		return Id.Equals(default);
	}
}