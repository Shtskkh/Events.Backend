using Events.Domain.Exceptions;
using Events.Domain.Shared.Errors;

namespace Events.Domain.Shared.ValueObjects;

/// <summary>
///     Объект пароля.
/// </summary>
public class Password : ValueObject
{
    public const int MinLength = 6;
    public const int MaxLength = 512;
    public static readonly char[] InvalidCharacters = [' ', '\t', '\n'];

    private Password()
    {
    }

    public Password(string password)
    {
        var value = new Text(password).Value;

        if (value.ContainsAny(InvalidCharacters))
            throw new DomainException(PasswordErrors.Invalid);

        switch (value.Length)
        {
            case < MinLength:
                throw new DomainException(PasswordErrors.LessThanMinLength);

            case > MaxLength:
                throw new DomainException(PasswordErrors.GreaterThanMaxLength);
        }

        Value = value;
    }

    public string Value { get; } = null!;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}