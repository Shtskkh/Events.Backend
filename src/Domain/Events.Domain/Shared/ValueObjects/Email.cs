using Events.Domain.Exceptions;
using Events.Domain.Shared.Errors;

namespace Events.Domain.Shared.ValueObjects;

/// <summary>
///     Объект почтового адреса.
/// </summary>
public class Email : ValueObject
{
    private Email()
    {
    }

    /// <summary>
    ///     Конструктор.
    /// </summary>
    /// <param name="emailAddress">Почтовый адрес.</param>
    /// <exception cref="DomainException">Ошибка правил домена.</exception>
    public Email(string emailAddress)
    {
        var value = new Text(emailAddress).Value;

        if (!RegularExpressions.Email.IsMatch(value))
            throw new DomainException(EmailErrorMessages.Invalid);

        if (value.Length > DomainConstraints.Email.MaxLength)
            throw new DomainException(EmailErrorMessages.GreaterThanMaxLength);

        Value = value;
    }

    /// <summary>
    ///     Строка почтового адреса.
    /// </summary>
    public string Value { get; } = null!;

    /// <inheritdoc />
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}