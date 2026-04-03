using Events.Domain.Exceptions;
using Events.Domain.Shared.Constraints;
using Events.Domain.Shared.Errors;

namespace Events.Domain.Shared.ValueObjects;

/// <summary>
///     Объект пароля.
/// </summary>
public class Password : ValueObject
{
    private Password()
    {
    }

    /// <summary>
    ///     Конструктор.
    /// </summary>
    /// <param name="password">Пароль.</param>
    /// <exception cref="DomainException">Ошибка правил домена.</exception>
    public Password(string password)
    {
        var value = new Text(password).Value;

        if (value.ContainsAny(PasswordConstraints.InvalidCharacters))
            throw new DomainException(PasswordErrorMessages.Invalid);

        switch (value.Length)
        {
            case < PasswordConstraints.MinLength:
                throw new DomainException(PasswordErrorMessages.LessThanMinLength);

            case > PasswordConstraints.MaxLength:
                throw new DomainException(PasswordErrorMessages.GreaterThanMaxLength);
        }

        Value = value;
    }

    /// <summary>
    ///     Строка пароля.
    /// </summary>
    public string Value { get; } = null!;

    /// <inheritdoc />
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}