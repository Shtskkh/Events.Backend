using Events.Domain.Entities;
using FluentAssertions;

namespace Events.Unit.Tests.Domain.Entities;

public class TagTests
{
	[Fact]
	public void Constructor_WithTitleContainingSpaces_ThrowsArgumentException()
	{
		var createTag = () => new Tag(1, "Hello World");

		createTag.Should()
			.Throw<ArgumentException>()
			.WithMessage("Название тэга не должно содержать пробелов.");
	}

	[Fact]
	public void Constructor_WithTitleContainingSpacesAfterTrim_ThrowsArgumentException()
	{
		var createTag = () => new Tag(1, " Hello World ");

		createTag.Should()
			.Throw<ArgumentException>()
			.WithMessage("Название тэга не должно содержать пробелов.");
	}
}