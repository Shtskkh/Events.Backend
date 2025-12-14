using Events.Domain.Aggregates.EventAggregate;
using Events.Domain.Aggregates.EventAggregate.ValueObjects;
using Events.Unit.Tests.Domain.Aggregates.EventAggregate.Helpers;
using FluentAssertions;

namespace Events.Unit.Tests.Domain.Aggregates.EventAggregate;

public class EventFormatBehaviorTests
{
    [Fact]
    public void ChangeFormat_ShouldChangeFormat()
    {
        // Arrange
        var @event = new EventTestBuilder()
            .WithFormat(EventFormat.Online)
            .Build();
        var newFormat = EventFormat.Offline;

        // Act
        @event.ChangeFormat(newFormat);

        // Assert
        @event.Format.Should().Be(newFormat);
    }
}