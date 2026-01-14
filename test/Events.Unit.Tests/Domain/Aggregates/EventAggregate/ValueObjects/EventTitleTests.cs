using Events.Domain.Aggregates.EventAggregate.ValueObjects;
using Events.Domain.Exceptions;
using Events.Domain.Shared;
using FluentAssertions;

namespace Events.Unit.Tests.Domain.Aggregates.EventAggregate.ValueObjects;

public class EventTitleTests
{
    [Fact]
    public void Constructor_ValidValues_DoesNotThrow()
    {
        // Arrange
        var titleValidFirst = new string('t', DomainConstraints.Event.Title.MaxLength - 1);
        var titleValidSecond = new string('t', DomainConstraints.Event.Title.MinLength + 1);

        // Act
        var createEventTitleFirst = () => new EventTitle(titleValidFirst);
        var createEventTitleSecond = () => new EventTitle(titleValidSecond);

        // Assert
        createEventTitleFirst.Should().NotThrow();
        createEventTitleFirst.Should()
            .Subject.Invoke()
            .Value.Should().Be(titleValidFirst);

        createEventTitleSecond.Should().NotThrow();
        createEventTitleSecond.Should()
            .Subject.Invoke()
            .Value.Should().Be(titleValidSecond);
    }

    [Fact]
    public void Constructor_ValueLessThanMin_ThrowsDomainException()
    {
        // Arrange
        var title = new string('t', DomainConstraints.Event.Title.MinLength - 1);

        // Act
        var createEventTitle = () => new EventTitle(title);

        // Assert
        createEventTitle.Should().Throw<DomainException>()
            .WithMessage(DomainErrorMessages.Event.Title.LessThanMinLenght);
    }

    [Fact]
    public void Constructor_ValueGreaterThanMax_ThrowsDomainException()
    {
        // Arrange
        var title = new string('t', DomainConstraints.Event.Title.MaxLength + 1);

        // Act
        var createEventTitle = () => new EventTitle(title);

        // Assert
        createEventTitle.Should().Throw<DomainException>()
            .WithMessage(DomainErrorMessages.Event.Title.GreaterThanMaxLength);
    }
}