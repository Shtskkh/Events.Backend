using Events.Domain.Aggregates.EventAggregate.ValueObjects;
using Events.Domain.Exceptions;
using Events.Domain.Shared;
using FluentAssertions;

namespace Events.Unit.Tests.Domain.Aggregates.EventAggregate.ValueObjects;

public class EventDescriptionTests
{
    [Fact]
    public void Constructor_WithNullDescription_ThrowsDomainException()
    {
        // Act
        var createEventDescription = () => new EventDescription(null);

        // Assert
        createEventDescription.Should()
            .Throw<DomainException>()
            .WithMessage(DomainErrorMessages.EventDescriptionErrors.EventDescriptionNullOrWhiteSpace);
    }

    [Fact]
    public void Constructor_WithEmptyDescription_ThrowsDomainException()
    {
        // Act
        var createEventDescription = () => new EventDescription(string.Empty);

        // Assert
        createEventDescription.Should()
            .Throw<DomainException>()
            .WithMessage(DomainErrorMessages.EventDescriptionErrors.EventDescriptionNullOrWhiteSpace);
    }

    [Fact]
    public void Constructor_WithWhitespaceOnlyDescription_ThrowsDomainException()
    {
        // Act
        var createEventDescription = () => new EventDescription(new string(' ', 10));

        // Assert
        createEventDescription.Should()
            .Throw<DomainException>()
            .WithMessage(DomainErrorMessages.EventDescriptionErrors.EventDescriptionNullOrWhiteSpace);
    }

    [Fact]
    public void Constructor_WithDescriptionLengthLessThanConstraint_ThrowsDomainException()
    {
        // Act
        var createEventDescription = () =>
            new EventDescription(new string('a', DomainConstraints.EventDescription.MinLength - 1));

        // Assert
        createEventDescription.Should()
            .Throw<DomainException>()
            .WithMessage(DomainErrorMessages.EventDescriptionErrors.EventDescriptionLessThanMinLength);
    }

    [Fact]
    public void Constructor_WithDescriptionLengthGreaterThanConstraint_ThrowsDomainException()
    {
        // Act
        var createEventDescription = () =>
            new EventDescription(new string('a', DomainConstraints.EventDescription.MaxLength + 1));

        // Assert
        createEventDescription.Should()
            .Throw<DomainException>()
            .WithMessage(DomainErrorMessages.EventDescriptionErrors.EventDescriptionGreaterThanMaxLength);
    }
}