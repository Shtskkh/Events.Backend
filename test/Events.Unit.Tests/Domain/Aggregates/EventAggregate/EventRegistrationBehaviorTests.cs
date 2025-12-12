using Events.Unit.Tests.Domain.Aggregates.EventAggregate.Helpers;
using FluentAssertions;

namespace Events.Unit.Tests.Domain.Aggregates.EventAggregate;

public class EventRegistrationBehaviorTests
{
    [Fact]
    public void ChangeIsNeedsRegistration_ShouldChangeIsNeedsRegistration()
    {
        // Arrange
        var @event = new EventTestBuilder().WithNeedsRegistration(false).Build();
        const bool isNeedsRegistration = true;

        // Act
        @event.ChangeIsNeedsRegistration(isNeedsRegistration);

        // Assert
        @event.IsNeedsRegistration.Should().Be(isNeedsRegistration);
    }
}