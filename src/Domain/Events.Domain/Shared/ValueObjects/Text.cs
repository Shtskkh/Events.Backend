using Events.Domain.Exceptions;
using Events.Domain.Shared.Errors;

namespace Events.Domain.Shared.ValueObjects;

/// <summary>
///     Объект текста.
/// </summary>
public class Text : ValueObject
{
    public Text(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            throw new DomainException(TextErrors.NullOrWhiteSpace);

        Value = text.Trim();
    }

    public string Value { get; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}