using Events.Domain.Exceptions;
using Events.Domain.Shared.Errors;

namespace Events.Domain.Shared.ValueObjects;

/// <summary>
///     Объект текста.
/// </summary>
public class Text : ValueObject
{
    /// <summary>
    ///     Конструктор объекта текста.
    /// </summary>
    /// <param name="text">Текст.</param>
    /// <exception cref="DomainException">
    ///     Ошибка правил домена.
    /// </exception>
    public Text(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            throw new DomainException(TextErrorMessages.NullOrWhiteSpace);

        Value = text.Trim();
    }

    /// <summary>
    ///     Строка текста.
    /// </summary>
    public string Value { get; }

    /// <inheritdoc />
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}