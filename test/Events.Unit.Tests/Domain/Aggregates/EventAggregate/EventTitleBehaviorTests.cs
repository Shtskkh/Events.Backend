using Events.Unit.Tests.Domain.Aggregates.EventAggregate.Helpers;
using FluentAssertions;

namespace Events.Unit.Tests.Domain.Aggregates.EventAggregate;

public class EventTitleBehaviorTests
{
    [Fact]
    public void ChangeTitle_ShouldChangeTitle()
    {
        // Arrange
        var @event = new EventTestBuilder().Build();
        const string newTitle = "New title";

        // Act
        @event.ChangeTitle(newTitle);

        // Assert
        @event.Title.Value.Should().Be(newTitle);
    }
}