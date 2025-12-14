using Events.Domain.Entities;
using Events.Domain.Exceptions;
using Events.Domain.Shared;
using FluentAssertions;

namespace Events.Unit.Tests.Domain.Entities;

public class TagTests
{
    [Fact]
    public void Constructor_WithTitleContainingSpaces_ThrowsThrowsDomainException()
    {
        var createTag = () => new Tag(1, "Hello World");

        createTag.Should()
            .Throw<DomainException>()
            .WithMessage(DomainErrorMessages.TagErrors.TagContainsWhiteSpace);
    }

    [Fact]
    public void Constructor_WithTitleContainingSpacesAfterTrim_ThrowsDomainException()
    {
        var createTag = () => new Tag(1, " Hello World ");

        createTag.Should()
            .Throw<DomainException>()
            .WithMessage(DomainErrorMessages.TagErrors.TagContainsWhiteSpace);
    }

    [Fact]
    public void Constructor_WithTitleLengthLessThanConstraint_ThrowsDomainException()
    {
        var createTag = () => new Tag(1, "a");

        createTag.Should()
            .Throw<DomainException>()
            .WithMessage(DomainErrorMessages.TagErrors.TagLessThanMinLength);
    }

    [Fact]
    public void Constructor_WithTitleLengthGreaterThanConstraint_ThrowsDomainException()
    {
        var createTag = () => new Tag(1, new string('a', 33));

        createTag.Should()
            .Throw<DomainException>()
            .WithMessage(DomainErrorMessages.TagErrors.TagGreaterThanMaxLength);
    }
}