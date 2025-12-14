using Events.Domain.Aggregates.EventAggregate.ValueObjects;
using Events.Domain.Exceptions;
using Events.Domain.Shared;
using FluentAssertions;

namespace Events.Unit.Tests.Domain.Aggregates.EventAggregate.ValueObjects;

public class EventTitleTests
{
    [Fact]
    public void Constructor_WithTitleLengthLessThanConstraint_ThrowsDomainException()
    {
        // Act
        var createEventTitle = () =>
            new EventTitle(new string('t', DomainConstraints.EventTitle.MinLength - 1));

        // Assert
        createEventTitle.Should()
            .Throw<DomainException>()
            .WithMessage(DomainErrorMessages.EventTitleErrors.EventTitleLessThanMinLength);
    }

    [Fact]
    public void Constructor_WithTitleLengthGreaterThanConstraint_ThrowsDomainException()
    {
        // Act
        var createEventTitle = () =>
            new EventTitle(new string('t', DomainConstraints.EventTitle.MaxLength + 1));

        // Assert
        createEventTitle.Should()
            .Throw<DomainException>()
            .WithMessage(DomainErrorMessages.EventTitleErrors.EventTitleGreaterThanMaxLength);
    }
}