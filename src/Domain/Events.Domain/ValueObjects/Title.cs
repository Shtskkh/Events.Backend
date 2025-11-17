using Events.Domain.Shared;

namespace Events.Domain.ValueObjects;

/// <summary>
/// Объект названия.
/// </summary>
public class Title : ValueObject
{
	/// <summary>
	/// Строка названия.
	/// </summary>
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

	/// <inheritdoc/>
	protected override IEnumerable<object> GetEqualityComponents()
	{
		yield return Value;
	}
}