using Events.Domain.Aggregates.EventAggregate;
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
            .WithMessage(DomainErrorMessages.Tag.TagAlreadyAdded);
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
            .WithMessage(DomainErrorMessages.Tag.TagNotFound);
    }

    [Fact]
    public void AddPostToExternalService_ShouldAddPost_WhenServiceNotUsedYet()
    {
        // Arrange
        var link = new Uri("https://vk.com/wall123");

        // Act
        _event.AddPost(1, link);

        // Assert
        _event.Posts.Should().HaveCount(1);
        var post = _event.Posts.Single();
        post.EventId.Should().Be(EventId);
        post.ExternalServiceId.Should().Be(1);
        post.Link.Should().Be(link);
    }

    [Fact]
    public void AddPost_ShouldThrow_WhenSameServiceAlreadyHasPost()
    {
        // Arrange
        var link1 = new Uri("https://vk.com/wall1");
        var link2 = new Uri("https://vk.com/wall2");

        _event.AddPost(1, link1);

        // Act
        var act = () => _event.AddPost(1, link2);

        // Assert
        act.Should()
            .Throw<DomainException>()
            .WithMessage(DomainErrorMessages.Post.PostAlreadyExistForService);
    }

    [Fact]
    public void AddPost_ShouldAllowDifferentServices()
    {
        // Act
        _event.AddPost(1, new Uri("https://vk.com/1"));
        _event.AddPost(2, new Uri("https://t.me/1"));
        _event.AddPost(3, new Uri("https://twitter.com/1"));

        // Assert
        _event.Posts.Should().HaveCount(3);
    }

    [Fact]
    public void RemovePost_ShouldRemovePost_WhenExists()
    {
        // Arrange
        _event.AddPost(1, new Uri("https://example.com"));

        // Act
        _event.RemovePost(1);

        // Assert
        _event.Posts.Should().BeEmpty();
    }

    [Fact]
    public void RemovePost_ShouldThrow_WhenNoPostForService()
    {
        // Act
        var act = () => _event.RemovePost(1);

        // Assert
        act.Should()
            .Throw<DomainException>()
            .WithMessage(DomainErrorMessages.Post.PostNotFoundInService);
    }
}