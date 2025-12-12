using Events.Domain.Entities;
using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Unit.Tests.Domain.Aggregates.EventAggregate.Helpers;
using FluentAssertions;

namespace Events.Unit.Tests.Domain.Aggregates.EventAggregate;

public class EventTagsBehaviorTests
{
    [Fact]
    public void AddTag_ShouldAddTag_WhenTagNotExists()
    {
        // Arrange
        var @event = new EventTestBuilder().Build();
        var tag = new Tag(1, "test");

        // Act
        @event.AddTag(tag);

        // Assert
        @event.Tags.Should().HaveCount(1);
        @event.Tags.Single().Should().Be(tag);
    }

    [Fact]
    public void AddTag_ShouldThrowDomainException_WhenTagAlreadyAdded()
    {
        // Arrange
        var @event = new EventTestBuilder().Build();
        var tag = new Tag(1, "test");

        // Act
        @event.AddTag(tag);
        var act = () => @event.AddTag(tag);

        // Assert
        act.Should()
            .Throw<DomainException>()
            .WithMessage(DomainErrorMessages.TagErrors.TagAlreadyAdded);
    }

    [Fact]
    public void RemoveTag_ShouldRemoveTag_WhenExists()
    {
        // Arrange
        var @event = new EventTestBuilder().Build();
        var tag = new Tag(1, "test");

        // Act
        @event.AddTag(tag);
        @event.RemoveTag(tag);

        // Assert
        @event.Tags.Should().BeEmpty();
    }

    [Fact]
    public void RemoveTag_ShouldThrowDomainException_WhenTagNotFound()
    {
        // Arrange
        var @event = new EventTestBuilder().Build();
        var tag = new Tag(1, "test");

        // Act
        var act = () => @event.RemoveTag(tag);

        // Assert
        act.Should()
            .Throw<DomainException>()
            .WithMessage(DomainErrorMessages.TagErrors.TagNotFound);
    }
}