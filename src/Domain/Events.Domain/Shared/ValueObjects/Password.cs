using Events.Domain.Exceptions;

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

        if (value.ContainsAny(DomainConstraints.Password.InvalidCharacters))
            throw new DomainException(DomainErrorMessages.Password.Invalid);

        switch (value.Length)
        {
            case < DomainConstraints.Password.MinLength:
                throw new DomainException(DomainErrorMessages.Password.LessThanMinLength);

            case > DomainConstraints.Password.MaxLength:
                throw new DomainException(DomainErrorMessages.Password.GreaterThanMaxLength);
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