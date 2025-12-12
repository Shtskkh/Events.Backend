using Events.Unit.Tests.Domain.Aggregates.EventAggregate.Helpers;
using FluentAssertions;

namespace Events.Unit.Tests.Domain.Aggregates.EventAggregate;

public class EventAnnouncementBehaviorTests
{
    [Fact]
    public void ChangeAnnouncement_ShouldChangeAnnouncement()
    {
        // Arrange
        var @event = new EventTestBuilder().Build();
        const string newAnnouncement = "New  announcement";

        // Act
        @event.ChangeAnnouncement(newAnnouncement);

        // Assert
        @event.Announcement.Value.Should().Be(newAnnouncement);
    }
}