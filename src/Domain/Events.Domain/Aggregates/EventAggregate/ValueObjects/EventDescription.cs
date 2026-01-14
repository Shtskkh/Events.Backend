using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Domain.Shared.ValueObjects;

namespace Events.Domain.Aggregates.EventAggregate.ValueObjects;

public class EventDescription : ValueObject
{
    public EventDescription(string description)
    {
        Description = new Text(description);

        switch (Description.Value.Length)
        {
            case < DomainConstraints.Event.Description.MinLength:
                throw new DomainException(DomainErrorMessages.Event.Description.LessThanMinLenght);

            case > DomainConstraints.Event.Description.MaxLength:
                throw new DomainException(DomainErrorMessages.Event.Description.GreaterThanMaxLength);
        }
    }

    private Text Description { get; }

    public string Value => Description.Value;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}