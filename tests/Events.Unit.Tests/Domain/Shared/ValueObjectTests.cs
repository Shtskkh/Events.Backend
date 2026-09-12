using Events.Domain.Shared;
using FluentAssertions;

namespace Events.Unit.Tests.Domain.Shared;

/// <summary>
///     Тесты для абстрактного класса ValueObject.
/// </summary>
public class ValueObjectTests
{
    // Вспомогательная конкретная реализация для тестирования

    private sealed class TestValueObject(params object[] components) : ValueObject
    {
        protected override IEnumerable<object> GetEqualityComponents()
        {
            foreach (var c in components) yield return c;
        }
    }
    
    // Equals
    
    [Fact]
    public void Equals_SameComponents_ReturnsTrue()
    {
        // Arrange
        var a = new TestValueObject("hello", 42);
        var b = new TestValueObject("hello", 42);

        // Act & Assert
        a.Equals(b).Should().BeTrue();
    }

    [Fact]
    public void Equals_DifferentComponents_ReturnsFalse()
    {
        // Arrange
        var a = new TestValueObject("hello", 42);
        var b = new TestValueObject("world", 42);

        // Act & Assert
        a.Equals(b).Should().BeFalse();
    }

    [Fact]
    public void Equals_SameReference_ReturnsTrue()
    {
        // Arrange
        var a = new TestValueObject("x");

        // Act & Assert
        a.Equals(a).Should().BeTrue();
    }

    [Fact]
    public void Equals_Null_ReturnsFalse()
    {
        // Arrange
        var a = new TestValueObject("x");

        // Act & Assert
        a.Equals(null).Should().BeFalse();
    }

    [Fact]
    public void Equals_DifferentType_ReturnsFalse()
    {
        // Arrange
        var a = new TestValueObject("x");

        // Act & Assert
        a.Equals("x").Should().BeFalse();
    }
    
    // GetHashCode

    [Fact]
    public void GetHashCode_EqualObjects_ReturnsSameHash()
    {
        // Arrange
        var a = new TestValueObject("hello", 1);
        var b = new TestValueObject("hello", 1);

        // Act & Assert
        a.GetHashCode().Should().Be(b.GetHashCode());
    }

    [Fact]
    public void GetHashCode_DifferentObjects_ReturnsDifferentHash()
    {
        // Arrange
        var a = new TestValueObject("hello");
        var b = new TestValueObject("world");

        // Act & Assert
        a.GetHashCode().Should().NotBe(b.GetHashCode());
    }
    
    // Операторы == и !=

    [Fact]
    public void EqualityOperator_EqualObjects_ReturnsTrue()
    {
        // Arrange
        var a = new TestValueObject("x", 1);
        var b = new TestValueObject("x", 1);

        // Act & Assert
        (a == b).Should().BeTrue();
    }

    [Fact]
    public void InequalityOperator_DifferentObjects_ReturnsTrue()
    {
        // Arrange
        var a = new TestValueObject("x");
        var b = new TestValueObject("y");

        // Act & Assert
        (a != b).Should().BeTrue();
    }

    [Fact]
    public void EqualityOperator_BothNull_ReturnsTrue()
    {
        // Arrange
        TestValueObject? a = null;
        TestValueObject? b = null;

        // Act & Assert
        (a == b).Should().BeTrue();
    }

    [Fact]
    public void EqualityOperator_OneNull_ReturnsFalse()
    {
        // Arrange
        var a = new TestValueObject("x");
        TestValueObject? b = null;

        // Act & Assert
        (a == b).Should().BeFalse();
    }
}
