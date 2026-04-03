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
        LastName = new Text(lastName).Value;
        if (LastName.Length > DomainConstraints.User.PersonName.MaxLength)
            throw new DomainException(DomainErrorMessages.User.PersonName.LastNameGreaterThanMaxLength);

        FirstName = new Text(firstName).Value;
        if (FirstName.Length > DomainConstraints.User.PersonName.MaxLength)
            throw new DomainException(DomainErrorMessages.User.PersonName.FirstNameGreaterThanMaxLength);

        if (patronymic != null)
        {
            Patronymic = new Text(patronymic).Value;

            if (Patronymic.Length > DomainConstraints.User.PersonName.MaxLength)
                throw new DomainException(DomainErrorMessages.User.PersonName.PatronymicGreaterThanMaxLength);
        }
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