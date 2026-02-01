using Events.Domain.Aggregates.EventAggregate.ValueObjects;
using Events.Domain.Exceptions;
using Events.Domain.Shared;
using FluentAssertions;

namespace Events.Unit.Tests.Domain.Aggregates.EventAggregate.ValueObjects;

public class EventAnnouncementTests
{
    [Fact]
    public void Constructor_ValidValues_DoesNotThrow()
    {
        // Arrange
        var announcementValidFirst = new string('t', DomainConstraints.Event.Announcement.MaxLength - 1);
        var announcementValidSecond = new string('t', DomainConstraints.Event.Announcement.MinLength + 1);

        // Act
        var createEventAnnouncementFirst = () => new EventAnnouncement(announcementValidFirst);
        var createEventAnnouncementSecond = () => new EventAnnouncement(announcementValidSecond);

        // Assert
        createEventAnnouncementFirst.Should().NotThrow();
        createEventAnnouncementFirst.Should()
            .Subject.Invoke()
            .Value.Should().Be(announcementValidFirst);

        createEventAnnouncementSecond.Should().NotThrow();
        createEventAnnouncementSecond.Should()
            .Subject.Invoke()
            .Value.Should().Be(announcementValidSecond);
    }

    [Fact]
    public void Constructor_ValueLessThanMin_ThrowsDomainException()
    {
        // Arrange
        var announcement = new string('t', DomainConstraints.Event.Announcement.MinLength - 1);

        // Act
        var createEventAnnouncement = () => new EventAnnouncement(announcement);

        // Assert
        createEventAnnouncement.Should().Throw<DomainException>()
            .WithMessage(DomainErrorMessages.Event.Announcement.LessThanMinLenght);
    }

    [Fact]
    public void Constructor_ValueGreaterThanMax_ThrowsDomainException()
    {
        // Arrange
        var announcement = new string('t', DomainConstraints.Event.Announcement.MaxLength + 1);

        // Act
        var createEventAnnouncement = () => new EventAnnouncement(announcement);

        // Assert
        createEventAnnouncement.Should().Throw<DomainException>()
            .WithMessage(DomainErrorMessages.Event.Announcement.GreaterThanMaxLength);
    }
}