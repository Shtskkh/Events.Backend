using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Domain.Shared.ValueObjects;
using FluentAssertions;

namespace Events.Unit.Tests.Domain.Shared.ValueObjects;

public class TextTests
{
    [Fact]
    public void Constructor_ValidValue_DoesNotThrow()
    {
        const string str1 = "Hello World";
        var title1 = new Text(str1);

        const string str2 = " Hello World ";
        var title2 = new Text(str2);

        title1.Value.Should().Be(str1);
        title2.Value.Should().Be(str2.Trim());
        title1.Value.Should().Be(title1.Value);
    }

    [Fact]
    public void Constructor_WithNullValue_ThrowsDomainException()
    {
        var createTitle = () => new Text(null);

        createTitle.Should()
            .Throw<DomainException>()
            .WithMessage(DomainErrorMessages.Text.NullOrWhiteSpace);
    }

    [Fact]
    public void Constructor_WithEmptyValue_ThrowsDomainException()
    {
        var createTitle = () => new Text(string.Empty);

        createTitle.Should()
            .Throw<DomainException>()
            .WithMessage(DomainErrorMessages.Text.NullOrWhiteSpace);
    }

    [Fact]
    public void Constructor_WithWhitespaceOnlyValue_ThrowsDomainException()
    {
        var createTitle = () => new Text(" ");

        createTitle.Should()
            .Throw<DomainException>()
            .WithMessage(DomainErrorMessages.Text.NullOrWhiteSpace);
    }
}