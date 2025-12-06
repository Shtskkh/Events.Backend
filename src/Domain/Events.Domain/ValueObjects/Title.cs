using Events.Domain.Exceptions;
using Events.Domain.Shared;

namespace Events.Domain.ValueObjects;

/// <summary>
/// Объект названия.
/// </summary>
public class Title : ValueObject
{
    /// <summary>
    /// Строка названия.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="value">Значение для названия.</param>
    /// <exception cref="DomainException"><see cref="DomainErrorMessages.Title"/></exception>
    public Title(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new DomainException(DomainErrorMessages.Title.TitleNullOrWhiteSpace);
        }

        Value = value.Trim();
    }

    /// <inheritdoc/>
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}