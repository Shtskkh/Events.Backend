using Events.Domain.Exceptions;
using Events.Domain.Shared.Errors;

namespace Events.Domain.Shared.ValueObjects;

/// <summary>
///     Объект почтового адреса.
/// </summary>
public class Email : ValueObject
{
    public const int MaxLength = 512;

    private Email()
    {
    }

    public Email(string emailAddress)
    {
        var value = new Text(emailAddress).Value;

        if (!RegularExpressions.Email.IsMatch(value))
            throw new DomainException(EmailErrors.Invalid);

        if (value.Length > MaxLength)
            throw new DomainException(EmailErrors.GreaterThanMaxLength);

        Value = value;
    }

    public string Value { get; } = null!;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}