using Events.Domain.Aggregates.EventAggregate;
using Events.Domain.Entities;
using Events.Domain.Exceptions;
using FluentAssertions;

namespace Events.Unit.Tests.Domain.Aggregates;

public class EventTests
{
    private static readonly Guid EventId = Guid.NewGuid();
    private readonly Event _event = new(EventId);

    [Fact]
    public void AddTag_ShouldAddTag_WhenTagNotExists()
    {
        // Arrange
        const int tagId = 1;

        // Act
        _event.AddTag(tagId);

        // Assert
        _event.Tags.Should().HaveCount(1);
        _event.Tags.Single().TagId.Should().Be(tagId);
        _event.Tags.Single().EventId.Should().Be(EventId);
    }

    [Fact]
    public void AddTag_ShouldThrowDomainException_WhenTagAlreadyAdded()
    {
        // Arrange
        const int tagId = 1;
        _event.AddTag(tagId);

        // Act
        var act = () => _event.AddTag(tagId);

        // Assert
        act.Should()
            .Throw<DomainException>()
            .WithMessage(DomainErrorMessages.TagAlreadyAdded);
    }

    [Fact]
    public void AddTag_ShouldAllowDifferentTags()
    {
        // Act
        _event.AddTag(1);
        _event.AddTag(2);
        _event.AddTag(3);

        // Assert
        _event.Tags.Should().HaveCount(3);
    }

    [Fact]
    public void RemoveTag_ShouldRemoveTag_WhenExists()
    {
        // Arrange
        const int tagId = 1;
        _event.AddTag(tagId);

        // Act
        _event.RemoveTag(tagId);

        // Assert
        _event.Tags.Should().BeEmpty();
    }

    [Fact]
    public void RemoveTag_ShouldThrowDomainException_WhenTagNotFound()
    {
        // Arrange
        const int tagId = 1;

        // Act
        var act = () => _event.RemoveTag(tagId);

        // Assert
        act.Should()
            .Throw<DomainException>()
            .WithMessage(DomainErrorMessages.TagNotFound);
    }
}