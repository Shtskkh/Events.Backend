using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Unit.Tests.Domain.Aggregates.EventAggregate.Helpers;
using FluentAssertions;

namespace Events.Unit.Tests.Domain.Aggregates.EventAggregate;

public class EventDurationBehaviorTests
{
    [Fact]
    public void SetDateTimeRange_StartGreaterThanEnd_ShouldThrowDomainException()
    {
        // Arrange
        var @event = new EventTestBuilder().Build();

        // Act
        var act = () => @event.ChangeDateTimeRange(
            new DateTime(2020, 01, 02),
            new DateTime(2020, 01, 01));

        // Assert
        act.Should()
            .Throw<DomainException>()
            .WithMessage(DomainErrorMessages.EventDateTimeErrors.StartDateCannotBeLaterThanEndDate);
    }

    [Fact]
    public void SetDateTimeRange_DurationGreaterThanMax_ShouldThrowDomainException()
    {
        // Arrange
        var @event = new EventTestBuilder().Build();

        // Act
        var act = () => @event.ChangeDateTimeRange(
            new DateTime(2020, 01, 01),
            new DateTime(2021, 01, 01));

        // Assert
        act.Should()
            .Throw<DomainException>()
            .WithMessage(DomainErrorMessages.EventDateTimeErrors.DurationGreaterThanMax);
    }
}