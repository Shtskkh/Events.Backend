using Events.Domain.Exceptions;
using Events.Domain.Shared;

namespace Events.Domain.Aggregates.EventAggregate.ValueObjects;

/// <summary>
/// Описание мероприятия.
/// </summary>
public class EventDescription : ValueObject
{
    /// <summary>
    /// Строка описания.
    /// </summary>
    public string Value { get; }

    public EventDescription(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
        {
            throw new DomainException(DomainErrorMessages.EventDescriptionErrors.EventDescriptionNullOrWhiteSpace);
        }

        switch (description.Length)
        {
            case < DomainConstraints.EventDescription.MinLength:
                throw new DomainException(DomainErrorMessages.EventDescriptionErrors.EventDescriptionLessThanMinLength);

            case > DomainConstraints.EventDescription.MaxLength:
                throw new DomainException(DomainErrorMessages.EventDescriptionErrors
                    .EventDescriptionGreaterThanMaxLength);
        }

        Value = description.Trim();
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}