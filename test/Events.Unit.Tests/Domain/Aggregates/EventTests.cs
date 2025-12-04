using Events.Domain.Aggregates.EventAggregate;
using Events.Domain.Entities;
using Events.Domain.Exceptions;
using FluentAssertions;

namespace Events.Unit.Tests.Domain.Aggregates;

public class EventTests
{
    private readonly Guid _eventId = Guid.NewGuid();
    private const int TagId = 1;
    private const string TagTitle = "Test";

    [Fact]
    public void AddTag_ShouldAddNewTag_WhenTagNotExists()
    {
        // Arrange
        var eventEntity = new Event(_eventId);
        var tag = new Tag(TagId, TagTitle);

        // Act
        eventEntity.AddTag(tag);

        // Assert
        eventEntity.Tags.Should().HaveCount(1);

        var addedTag = eventEntity.Tags.First();
        addedTag.TagId.Should().Be(TagId);
    }

    [Fact]
    public void AddTag_ShouldThrowDomainException_WhenTagExists()
    {
        // Arrange
        var eventEntity = new Event(_eventId);
        var tag = new Tag(TagId, TagTitle);

        // Act
        eventEntity.AddTag(tag);
        var addTag = () => eventEntity.AddTag(tag);

        // Assert
        addTag.Should()
            .Throw<DomainException>()
            .WithMessage(DomainErrorMessages.TagAlreadyAdded);
    }

    [Fact]
    public void RemoveTag_ShouldRemoveTag_WhenTagExists()
    {
        // Arrange
        var eventEntity = new Event(_eventId);
        var tag = new Tag(TagId, TagTitle);

        // Act
        eventEntity.AddTag(tag);

        // Assert
        eventEntity.RemoveTag(TagId);
        eventEntity.Tags.Should().BeEmpty();
    }

    [Fact]
    public void RemoveTag_ShouldThrowInvalidOperationException_WhenTagNotExists()
    {
        // Arrange
        var eventEntity = new Event(_eventId);

        // Act
        var act = () => eventEntity.RemoveTag(TagId);

        // Assert
        act.Should()
            .Throw<DomainException>()
            .WithMessage(DomainErrorMessages.TagNotFound);
    }
}