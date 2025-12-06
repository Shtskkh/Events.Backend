using Events.Domain.Exceptions;
using Events.Domain.ValueObjects;
using FluentAssertions;

namespace Events.Unit.Tests.Domain.ValueObjects;

public class TitleTests
{
    [Fact]
    public void Constructor_ValidTitle_DoesNotThrow()
    {
        const string str1 = "Hello World";
        var title1 = new Title(str1);

        const string str2 = " Hello World ";
        var title2 = new Title(str2);

        title1.Value.Should().Be(str1);
        title2.Value.Should().Be(str2.Trim());
        title1.Value.Should().Be(title1.Value);
    }

    [Fact]
    public void Constructor_WithNullValue_ThrowsDomainException()
    {
        var createTitle = () => new Title(null);

        createTitle.Should()
            .Throw<DomainException>()
            .WithMessage(DomainErrorMessages.Title.TitleNullOrWhiteSpace);
    }

    [Fact]
    public void Constructor_WithEmptyTitle_ThrowsDomainException()
    {
        var createTitle = () => new Title(string.Empty);

        createTitle.Should()
            .Throw<DomainException>()
            .WithMessage(DomainErrorMessages.Title.TitleNullOrWhiteSpace);
    }

    [Fact]
    public void Constructor_WithWhitespaceOnlyTitle_ThrowsDomainException()
    {
        var createTitle = () => new Title(" ");

        createTitle.Should()
            .Throw<DomainException>()
            .WithMessage(DomainErrorMessages.Title.TitleNullOrWhiteSpace);
    }
}