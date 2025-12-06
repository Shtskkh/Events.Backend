using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Domain.ValueObjects;

namespace Events.Domain.Aggregates.EventAggregate.ValueObjects;

/// <summary>
/// Название мероприятия.
/// </summary>
public class EventTitle : Title
{
    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="title">Название.</param>
    /// <exception cref="DomainException"><see cref="DomainErrorMessages.EventTitle"/></exception>
    public EventTitle(string title) : base(title)
    {
        switch (title.Length)
        {
            case < DomainConstraints.EventTitle.MinLength:
                throw new DomainException(DomainErrorMessages.EventTitle.EventTitleLessThanMinLength);

            case > DomainConstraints.EventTitle.MaxLength:
                throw new DomainException(DomainErrorMessages.EventTitle.EventTitleGreaterThenMaxLength);
        }
    }
}