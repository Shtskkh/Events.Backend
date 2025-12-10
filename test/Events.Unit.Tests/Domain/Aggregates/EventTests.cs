using Events.Domain.Aggregates.EventAggregate;
using Events.Domain.Entities;
using Events.Domain.Exceptions;
using Events.Domain.Shared;
using FluentAssertions;

namespace Events.Unit.Tests.Domain.Aggregates;

public class EventTests
{
    private static readonly Guid EventId = Guid.NewGuid();
    private const string EventTitle = "Test test";
    private const string EventAnnouncement = "Test Announcement";
    private const string EventDescription = "Test Description";
    private const bool EventIsPublic = true;
    private const bool EventNeedsRegistration = true;

    private readonly Event _event = new(
        id: EventId,
        title: EventTitle,
        announcement: EventAnnouncement,
        description: EventDescription,
        isPublic: EventIsPublic,
        isNeedsRegistration: EventNeedsRegistration
    );

    [Fact]
    public void Constructor_ShouldSetMaxParticipantsToZero_ByDefault()
    {
        // Assert
        _event.EventMaxParticipants.Should().Be(0);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(2)]
    [InlineData(100)]
    public void Constructor_WithValidMaxParticipants_ShouldSetCorrectly(int maxParticipants)
    {
        // Act
        var @event = new Event(
            Guid.NewGuid(),
            EventTitle,
            EventAnnouncement,
            EventDescription,
            maxParticipants,
            EventIsPublic,
            EventNeedsRegistration
        );

        // Assert
        @event.EventMaxParticipants.Should().Be(maxParticipants);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(1)]
    public void Constructor_WithInvalidMaxParticipants_ShouldThrowDomainException(int maxParticipants)
    {
        // Act
        var act = () => new Event(
            Guid.NewGuid(),
            EventTitle,
            EventAnnouncement,
            EventDescription,
            maxParticipants,
            EventIsPublic,
            EventNeedsRegistration
        );

        // Assert
        act.Should()
            .Throw<DomainException>()
            .WithMessage(DomainErrorMessages.EventErrors.MaxParticipantsCountLessThanMin);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(2)]
    [InlineData(100)]
    public void ChangeMaxParticipants_WithValidValue_ShouldChangeCorrectly(int newMaxParticipants)
    {
        // Act
        _event.ChangeMaxParticipants(newMaxParticipants);

        // Assert
        _event.EventMaxParticipants.Should().Be(newMaxParticipants);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(1)]
    public void ChangeMaxParticipants_WithInvalidValue_ShouldThrowDomainException(int newMaxParticipants)
    {
        // Act
        var act = () => _event.ChangeMaxParticipants(newMaxParticipants);

        act.Should()
            .Throw<DomainException>()
            .WithMessage(DomainErrorMessages.EventErrors.MaxParticipantsCountLessThanMin);
    }

    [Fact]
    public void ChangeTitle_ShouldChangeTitle()
    {
        // Arrange
        const string newTitle = "New Title";

        // Act
        _event.ChangeTitle(newTitle);

        // Assert
        _event.Title.Value.Should().Be(newTitle);
    }

    [Fact]
    public void ChangeAnnouncement_ShouldChangeAnnouncement()
    {
        // Arrange
        const string newAnnouncement = "New Announcement";

        // Act
        _event.ChangeAnnouncement(newAnnouncement);

        // Assert
        _event.Announcement.Value.Should().Be(newAnnouncement);
    }

    [Fact]
    public void ChangeIsPublic_ShouldChangeIsPublic()
    {
        // Arrange
        const bool isNotPublic = false;

        // Act
        _event.ChangeIsPublic(isNotPublic);

        // Assert
        _event.IsPublic.Should().Be(isNotPublic);
    }

    [Fact]
    public void ChangeDescription_ShouldChangeDescription()
    {
        // Arrange
        const string newDescription = "New Description";

        // Act
        _event.ChangeDescription(newDescription);

        // Assert
        _event.Description.Value.Should().Be(newDescription);
    }

    [Fact]
    public void ChangeIsNeedsRegistration_ShouldChangeIsNeedsRegistration()
    {
        // Arrange
        const bool isNotNeedsRegistration = false;

        // Act
        _event.ChangeIsNeedsRegistration(isNotNeedsRegistration);

        // Assert
        _event.IsNeedsRegistration.Should().Be(isNotNeedsRegistration);
    }

    [Fact]
    public void AddTag_ShouldAddTag_WhenTagNotExists()
    {
        // Arrange
        var tag = new Tag(1, "test");

        // Act
        _event.AddTag(tag);

        // Assert
        _event.Tags.Should().HaveCount(1);
        _event.Tags.Single().Should().Be(tag);
    }

    [Fact]
    public void AddTag_ShouldThrowDomainException_WhenTagAlreadyAdded()
    {
        // Arrange
        var tag = new Tag(1, "test");
        _event.AddTag(tag);

        // Act
        var act = () => _event.AddTag(tag);

        // Assert
        act.Should()
            .Throw<DomainException>()
            .WithMessage(DomainErrorMessages.TagErrors.TagAlreadyAdded);
    }

    [Fact]
    public void AddTag_ShouldAllowDifferentTags()
    {
        // Act
        _event.AddTag(new Tag(1, "test"));
        _event.AddTag(new Tag(2, "test"));
        _event.AddTag(new Tag(3, "test"));

        // Assert
        _event.Tags.Should().HaveCount(3);
    }

    [Fact]
    public void RemoveTag_ShouldRemoveTag_WhenExists()
    {
        // Arrange
        var tag = new Tag(1, "test");
        _event.AddTag(tag);

        // Act
        _event.RemoveTag(tag);

        // Assert
        _event.Tags.Should().BeEmpty();
    }

    [Fact]
    public void RemoveTag_ShouldThrowDomainException_WhenTagNotFound()
    {
        // Arrange
        var tag = new Tag(1, "test");

        // Act
        var act = () => _event.RemoveTag(tag);

        // Assert
        act.Should()
            .Throw<DomainException>()
            .WithMessage(DomainErrorMessages.TagErrors.TagNotFound);
    }

    [Fact]
    public void AddPost_ShouldAddPost()
    {
        // Arrange
        const int postId = 1;
        const int serviceId = 1;
        var link = new Uri("https://test.com/test");

        // Act
        _event.AddPost(postId, serviceId, link);

        // Assert
        _event.Posts.Should().HaveCount(1);
        var post = _event.Posts.Single();

        post.Id.Should().Be(postId);
        post.EventId.Should().Be(EventId);
        post.ExternalServiceId.Should().Be(serviceId);
        post.Link.Should().Be(link);
    }

    [Fact]
    public void RemovePost_ShouldRemovePost()
    {
        // Arrange
        const int postId = 1;
        const int serviceId = 1;
        var link = new Uri("https://test.com/test");

        // Act
        _event.AddPost(postId, serviceId, link);
        _event.RemovePost(postId);

        // Assert
        _event.Posts.Should().BeEmpty();
    }

    [Fact]
    public void RemovePost_ShouldThrowDomainException_WhenPostNotFound()
    {
        // Act
        var act = () => _event.RemovePost(1);

        // Assert
        act.Should()
            .Throw<DomainException>()
            .WithMessage(DomainErrorMessages.PostErrors.PostNotFound);
    }
}