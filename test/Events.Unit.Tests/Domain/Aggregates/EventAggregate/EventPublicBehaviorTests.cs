using Events.Unit.Tests.Domain.Aggregates.EventAggregate.Helpers;
using FluentAssertions;

namespace Events.Unit.Tests.Domain.Aggregates.EventAggregate;

public class EventPublicBehaviorTests
{
    [Fact]
    public void ChangeIsPublic_ShouldChangeIsPublic()
    {
        // Arrange
        var @event = new EventTestBuilder().WithIsPublic(true).Build();
        const bool isNotPublic = false;

        // Act
        @event.ChangeIsPublic(isNotPublic);

        // Assert
        @event.IsPublic.Should().Be(isNotPublic);
    }
}