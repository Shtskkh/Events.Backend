using Events.Domain.Shared;

namespace Events.Domain.ValueObjects;

/// <summary>
/// Название.
/// </summary>
public class Title : ValueObject
{
	public string Value { get; }

	public Title(string value)
	{
		if (string.IsNullOrWhiteSpace(value))
		{
			throw new ArgumentException(
				"Название не может быть null или пустым."
			);
		}

		Value = value.Trim();
	}

	protected override IEnumerable<object> GetEqualityComponents()
	{
		yield return Value;
	}
}