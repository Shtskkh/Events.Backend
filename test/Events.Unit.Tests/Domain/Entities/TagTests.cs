using Events.Domain.Entities;
using Events.Domain.Exceptions;
using FluentAssertions;

namespace Events.Unit.Tests.Domain.Entities;

public class TagTests
{
    [Fact]
    public void Constructor_WithTitleContainingSpaces_ThrowsArgumentException()
    {
        var createTag = () => new Tag(1, "Hello World");

        createTag.Should()
            .Throw<DomainException>()
            .WithMessage(DomainErrorMessages.Tag.TagContainsWhiteSpace);
    }

    [Fact]
    public void Constructor_WithTitleContainingSpacesAfterTrim_ThrowsArgumentException()
    {
        var createTag = () => new Tag(1, " Hello World ");

        createTag.Should()
            .Throw<DomainException>()
            .WithMessage(DomainErrorMessages.Tag.TagContainsWhiteSpace);
    }
}