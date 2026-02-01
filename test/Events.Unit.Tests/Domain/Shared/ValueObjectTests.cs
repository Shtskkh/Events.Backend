using Events.Domain.Shared;
using FluentAssertions;

namespace Events.Unit.Tests.Domain.Shared;

public class ValueObjectTests
{
    [Fact]
    public void Equals_ShouldReturnTrue_WhenSameReference()
    {
        // Arrange
        var obj = new TestValueObject(1, "Test");

        // Act
        var result = obj.Equals(obj);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void Equals_ShouldReturnFalse_WhenComparedToNull()
    {
        // Arrange
        var obj = new TestValueObject(1, "Test");

        // Act
        var result = obj.Equals(null);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Equals_ShouldReturnFalse_WhenDifferentTypes()
    {
        // Arrange
        var obj1 = new TestValueObject(1, "Test");
        var obj2 = new AnotherTestValueObject(1.0);

        // Act
        var result = obj1.Equals(obj2);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Equals_ShouldReturnTrue_WhenEqualityComponentsAreSame()
    {
        // Arrange
        var obj1 = new TestValueObject(1, "Test");
        var obj2 = new TestValueObject(1, "Test");

        // Act
        var result = obj1.Equals(obj2);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void Equals_ShouldReturnFalse_WhenEqualityComponentsDiffer()
    {
        // Arrange
        var obj1 = new TestValueObject(1, "Test");
        var obj2 = new TestValueObject(2, "Test");

        // Act
        var result = obj1.Equals(obj2);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Equals_ShouldHandleNullComponentsCorrectly()
    {
        // Arrange
        var obj1 = new TestValueObject(1, null);
        var obj2 = new TestValueObject(1, null);

        // Act
        var result = obj1.Equals(obj2);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void Equals_ShouldReturnFalse_WhenOneHasNullAndOtherDoesNot()
    {
        // Arrange
        var obj1 = new TestValueObject(1, null);
        var obj2 = new TestValueObject(1, "Test");

        // Act
        var result = obj1.Equals(obj2);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void GetHashCode_ShouldBeSame_WhenEqualityComponentsAreSame()
    {
        // Arrange
        var obj1 = new TestValueObject(1, "Test");
        var obj2 = new TestValueObject(1, "Test");

        // Act
        var hash1 = obj1.GetHashCode();
        var hash2 = obj2.GetHashCode();

        // Assert
        hash1.Should().Be(hash2);
    }

    [Fact]
    public void GetHashCode_ShouldBeDifferent_WhenEqualityComponentsDiffer()
    {
        // Arrange
        var obj1 = new TestValueObject(1, "Test");
        var obj2 = new TestValueObject(2, "Test");

        // Act
        var hash1 = obj1.GetHashCode();
        var hash2 = obj2.GetHashCode();

        // Assert
        hash1.Should().NotBe(hash2);
    }

    [Fact]
    public void GetHashCode_ShouldHandleNullComponents()
    {
        // Arrange
        var obj1 = new TestValueObject(1, null);
        var obj2 = new TestValueObject(1, null);
        // Act
        var hash1 = obj1.GetHashCode();
        var hash2 = obj2.GetHashCode();

        // Assert
        hash1.Should().Be(hash2);
    }

    [Fact]
    public void OperatorEquals_ShouldReturnTrue_WhenBothNull()
    {
        // Arrange
        TestValueObject? obj1 = null;
        TestValueObject? obj2 = null;

        // Act
        var result = obj1 == obj2;

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void OperatorEquals_ShouldReturnFalse_WhenOneNull()
    {
        // Arrange
        var obj1 = new TestValueObject(1, "Test");
        TestValueObject? obj2 = null;

        // Act
        var result = obj1 == obj2;

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void OperatorEquals_ShouldReturnTrue_WhenEqualityComponentsAreSame()
    {
        // Arrange
        var obj1 = new TestValueObject(1, "Test");
        var obj2 = new TestValueObject(1, "Test");

        // Act
        var result = obj1 == obj2;

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void OperatorNotEquals_ShouldReturnTrue_WhenEqualityComponentsDiffer()
    {
        // Arrange
        var obj1 = new TestValueObject(1, "Test");
        var obj2 = new TestValueObject(2, "Test");

        // Act
        var result = obj1 != obj2;

        // Assert
        result.Should().BeTrue();
    }
    
    private class TestValueObject : ValueObject
    {
        public TestValueObject(int id, string? name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }
        public string? Name { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
            yield return Name!;
        }
    }
    
    private class AnotherTestValueObject : ValueObject
    {
        public AnotherTestValueObject(double value)
        {
            Value = value;
        }

        public double Value { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}