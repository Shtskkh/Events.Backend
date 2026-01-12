using Events.Domain.Exceptions;

namespace Events.Domain.Shared.ValueObjects;

public class Text : ValueObject
{
    public Text(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            throw new DomainException(DomainErrorMessages.Text.NullOrWhiteSpace);

        Value = text.Trim();
    }

    public string Value { get; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}