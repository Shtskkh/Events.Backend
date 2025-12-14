using Events.Domain.Aggregates.EventAggregate.ValueObjects;
using Events.Domain.Exceptions;
using Events.Domain.Shared;
using FluentAssertions;

namespace Events.Unit.Tests.Domain.Aggregates.EventAggregate.ValueObjects;

public class EventAnnouncementTests
{
    [Fact]
    public void Constructor_WithNullValue_ThrowsDomainException()
    {
        // Act
        var createEventAnnouncement = () => new EventAnnouncement(null);

        // Assert
        createEventAnnouncement.Should()
            .Throw<DomainException>()
            .WithMessage(DomainErrorMessages.EventAnnouncementErrors.EventAnnouncementNullOrWhiteSpace);
    }

    [Fact]
    public void Constructor_WithEmptyTitle_ThrowsDomainException()
    {
        // Act
        var createEventAnnouncement = () => new EventAnnouncement(string.Empty);

        // Assert
        createEventAnnouncement.Should()
            .Throw<DomainException>()
            .WithMessage(DomainErrorMessages.EventAnnouncementErrors.EventAnnouncementNullOrWhiteSpace);
    }

    [Fact]
    public void Constructor_WithWhitespaceOnlyTitle_ThrowsDomainException()
    {
        // Act
        var createEventAnnouncement = () =>
            new EventAnnouncement(new string(' ', 10));

        // Assert
        createEventAnnouncement.Should()
            .Throw<DomainException>()
            .WithMessage(DomainErrorMessages.EventAnnouncementErrors.EventAnnouncementNullOrWhiteSpace);
    }

    [Fact]
    public void Constructor_WithTitleLengthLessThanConstraint_ThrowsDomainException()
    {
        // Act
        var createEventAnnouncement = () =>
            new EventAnnouncement(new string('a', DomainConstraints.EventAnnouncement.MinLength - 1));

        // Assert
        createEventAnnouncement.Should()
            .Throw<DomainException>()
            .WithMessage(DomainErrorMessages.EventAnnouncementErrors.EventAnnouncementLessThanMinLength);
    }

    [Fact]
    public void Constructor_WithTitleLengthGreaterThanConstraint_ThrowsDomainException()
    {
        // Act
        var createEventAnnouncement = () =>
            new EventAnnouncement(new string('a', DomainConstraints.EventAnnouncement.MaxLength + 1));

        // Assert
        createEventAnnouncement.Should()
            .Throw<DomainException>()
            .WithMessage(DomainErrorMessages.EventAnnouncementErrors.EventAnnouncementGreaterThanMaxLength);
    }
}