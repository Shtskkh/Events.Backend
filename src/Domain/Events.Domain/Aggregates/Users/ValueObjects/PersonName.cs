using Events.Domain.Aggregates.Users.Errors;
using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Domain.Shared.ValueObjects;

namespace Events.Domain.Aggregates.Users.ValueObjects;

/// <summary>
///     Объект ФИО пользователя.
/// </summary>
public class PersonName : ValueObject
{
    public const int MaxLength = 64;

    private PersonName()
    {
    }

    public PersonName(string lastName, string firstName, string? patronymic = null)
    {
        LastName = new Text(lastName).Value;
        if (LastName.Length > MaxLength)
            throw new DomainException(PersonNameErrors.LastNameGreaterThanMaxLength);

        FirstName = new Text(firstName).Value;
        if (FirstName.Length > MaxLength)
            throw new DomainException(PersonNameErrors.FirstNameGreaterThanMaxLength);

        if (patronymic != null)
        {
            Patronymic = new Text(patronymic).Value;

            if (Patronymic.Length > MaxLength)
                throw new DomainException(PersonNameErrors.PatronymicGreaterThanMaxLength);
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