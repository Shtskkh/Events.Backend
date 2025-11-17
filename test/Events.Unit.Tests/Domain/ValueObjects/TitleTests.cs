using Events.Domain.ValueObjects;

namespace Events.Unit.Tests.Domain.ValueObjects;

public class TitleTests
{
	[Fact]
	public void Constructor_ValidTitle_DoesNotThrow()
	{
		var str1 = "Hello World";
		var title1 = new Title(str1);

		var str2 = "Hello World ";
		var title2 = new Title(str2);

		Assert.Equal(str1, title1.Value);
		Assert.Equal(title2.Value, title2.Value);
	}

	[Fact]
	public void Constructor_WithNullValue_ThrowsArgumentException()
	{
		var ex = Assert.Throws<ArgumentException>(() => new Title(null));

		Assert.Equal(
			"Название не может быть null или пустым.",
			ex.Message
		);
	}

	[Fact]
	public void Constructor_WithEmptyTitle_ThrowsArgumentException()
	{
		var ex = Assert.Throws<ArgumentException>(() => new Title(""));

		Assert.Equal(
			"Название не может быть null или пустым.",
			ex.Message
		);
	}

	[Fact]
	public void Constructor_WithWhitespaceOnlyTitle_ThrowsArgumentException()
	{
		var ex = Assert.Throws<ArgumentException>(() => new Title("  "));

		Assert.Equal(
			"Название не может быть null или пустым.",
			ex.Message
		);
	}
}