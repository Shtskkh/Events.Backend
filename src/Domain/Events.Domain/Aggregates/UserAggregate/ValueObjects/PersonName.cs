using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Domain.Shared.ValueObjects;

namespace Events.Domain.Aggregates.UserAggregate.ValueObjects;

/// <summary>
///     Объект ФИО пользователя.
/// </summary>
public class PersonName : ValueObject
{
    private PersonName()
    {
    }

    /// <summary>
    ///     Конструктор.
    /// </summary>
    /// <param name="lastName">Фамилия.</param>
    /// <param name="firstName">Имя.</param>
    /// <param name="patronymic">Отчество.</param>
    /// <exception cref="DomainException"></exception>
    public PersonName(string lastName, string firstName, string? patronymic = null)
    {
        var lastNameValue = new Text(lastName).Value;
        var firstNameValue = new Text(firstName).Value;
        if (firstNameValue.Length > DomainConstraints.User.PersonName.MaxLength)
            throw new DomainException(DomainErrorMessages.User.PersonName.FirstNameGreaterThanMaxLength);

        if (lastNameValue.Length > DomainConstraints.User.PersonName.MaxLength)
            throw new DomainException(DomainErrorMessages.User.PersonName.LastNameGreaterThanMaxLength);

        if (patronymic != null)
        {
            var patronymicValue = new Text(patronymic).Value;

            if (patronymicValue.Length > DomainConstraints.User.PersonName.MaxLength)
                throw new DomainException(DomainErrorMessages.User.PersonName.PatronymicGreaterThanMaxLength);

            Patronymic = patronymicValue;
        }

        FirstName = firstNameValue;
        LastName = lastNameValue;
    }

    /// <summary>
    ///     Фамилия.
    /// </summary>
    public string LastName { get; } = null!;

    /// <summary>
    ///     Имя.
    /// </summary>
    public string FirstName { get; } = null!;

    /// <summary>
    ///     Отчество.
    /// </summary>
    public string? Patronymic { get; }

    /// <inheritdoc />
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return LastName;
        yield return FirstName;
        yield return Patronymic;
    }
}