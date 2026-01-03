using Events.Domain.Aggregates.EventAggregate;
using Events.Domain.Entities;
using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Unit.Tests.Domain.Aggregates.EventAggregate.Helpers;
using FluentAssertions;

namespace Events.Unit.Tests.Domain.Aggregates.EventAggregate;

public class EventPostBehaviorTests
{
    private static readonly Uri VkLink = new("https://vk.com/wall123_456");

    [Fact]
    public void AddPost_Should_AddPost()
    {
        // Arrange
        var @event = new EventTestBuilder().Build();

        // Act
        @event.AddPost(ExternalService.Vk, VkLink);

        // Assert
        @event.Posts.Count.Should().Be(1);
        @event.Posts.Single().Id.Should().NotBe(Guid.Empty);
        @event.Posts.Single().ExternalService.Should().Be(ExternalService.Vk);
        @event.Posts.Single().Link.Should().Be(VkLink);
    }

    [Fact]
    public void RemovePost_Should_RemoveExistingPost()
    {
        // Arrange
        var @event = new EventTestBuilder().Build();

        // Act
        @event.AddPost(ExternalService.Vk, VkLink);
        var post = @event.Posts.Single();
        @event.RemovePost(post);

        // Assert
        @event.Posts.Should().HaveCount(0);
    }

    [Fact]
    public void RemovePost_Should_ThrowException_WhenPostDoesNotExist()
    {
        // Arrange
        var @event = new EventTestBuilder().Build();

        // Act
        var act = () => @event.RemovePost(new EventPost(ExternalService.Vk, VkLink));

        // Assert
        act.Should()
            .Throw<DomainException>()
            .WithMessage(DomainErrorMessages.EventPostErrors.PostNotFound);
    }
}