using Events.Unit.Tests.Domain.Aggregates.EventAggregate.Helpers;
using FluentAssertions;

namespace Events.Unit.Tests.Domain.Aggregates.EventAggregate;

public class EventDescriptionBehaviorTests
{
    [Fact]
    public void ChangeDescription_ShouldChangeDescription()
    {
        // Arrange
        var @event = new EventTestBuilder().Build();
        const string newDescription = "New description";

        // Act
        @event.ChangeDescription(newDescription);

        // Assert
        @event.Description.Value.Should().Be(newDescription);
    }
}