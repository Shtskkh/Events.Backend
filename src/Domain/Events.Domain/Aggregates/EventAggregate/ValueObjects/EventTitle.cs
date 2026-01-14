using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Domain.Shared.ValueObjects;

namespace Events.Domain.Aggregates.EventAggregate.ValueObjects;

public class EventTitle : ValueObject
{
    public EventTitle(string title)
    {
        Text = new Text(title);

        switch (Text.Value.Length)
        {
            case < DomainConstraints.Event.Title.MinLength:
                throw new DomainException(DomainErrorMessages.Event.Title.LessThanMinLenght);

            case > DomainConstraints.Event.Title.MaxLength:
                throw new DomainException(DomainErrorMessages.Event.Title.GreaterThanMaxLength);
        }
    }

    private Text Text { get; }

    public string Value => Text.Value;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}