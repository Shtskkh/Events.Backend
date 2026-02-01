using Events.Domain.Shared;
using FluentAssertions;

namespace Events.Unit.Tests.Domain.Shared;

public class EntityTests
{
    [Fact]
    public void Constructor_ShouldSetIdCorrectly_ForInt()
    {
        // Arrange
        const int expectedId = 1;

        // Act
        var entity = new TestEntityInt(expectedId);

        // Assert
        entity.Id.Should().Be(expectedId);
    }

    [Fact]
    public void Constructor_ShouldSetIdCorrectly_ForString()
    {
        // Arrange
        const string expectedId = "id";

        // Act
        var entity = new TestEntityString(expectedId);

        // Assert
        entity.Id.Should().Be(expectedId);
    }

    [Fact]
    public void Equals_ShouldReturnTrue_WhenSameReference()
    {
        // Arrange
        var entity = new TestEntityInt(1);

        // Act
        var result = entity.Equals(entity);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void Equals_ShouldReturnTrue_WhenSameId_ForInt()
    {
        // Arrange
        var entity1 = new TestEntityInt(1);
        var entity2 = new TestEntityInt(1);

        // Act
        var result = entity1.Equals(entity2);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void Equals_ShouldReturnTrue_WhenSameId_ForString()
    {
        // Arrange
        var entity1 = new TestEntityString("id");
        var entity2 = new TestEntityString("id");

        // Act
        var result = entity1.Equals(entity2);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void Equals_ShouldReturnFalse_WhenDifferentIds_ForInt()
    {
        // Arrange
        var entity1 = new TestEntityInt(1);
        var entity2 = new TestEntityInt(2);

        // Act
        var result = entity1.Equals(entity2);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Equals_ShouldReturnFalse_WhenDifferentIds_ForString()
    {
        // Arrange
        var entity1 = new TestEntityString("id1");
        var entity2 = new TestEntityString("id2");

        // Act
        var result = entity1.Equals(entity2);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Equals_ShouldReturnFalse_WhenDifferentTypes()
    {
        // Arrange
        var entity1 = new TestEntityInt(1);
        var entity2 = new DifferentEntity(1);

        // Act
        var result = entity1.Equals(entity2);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Equals_ShouldReturnFalse_WhenComparedToNull()
    {
        // Arrange
        var entity = new TestEntityInt(1);

        // Act
        var result = entity.Equals(null);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Equals_ShouldReturnFalse_WhenThisIdIsDefault()
    {
        // Arrange
        var entity1 = new TestEntityInt(default);
        var entity2 = new TestEntityInt(1);

        // Act
        var result = entity1.Equals(entity2);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Equals_ShouldReturnFalse_WhenOtherIdIsDefault()
    {
        // Arrange
        var entity1 = new TestEntityInt(1);
        var entity2 = new TestEntityInt(default);

        // Act
        var result = entity1.Equals(entity2);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Equals_ShouldReturnFalse_WhenBothIdsAreDefault()
    {
        // Arrange
        var entity1 = new TestEntityInt(default);
        var entity2 = new TestEntityInt(default);

        // Act
        var result = entity1.Equals(entity2);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Equals_ShouldReturnFalse_WhenNotAnEntity()
    {
        // Arrange
        var entity = new TestEntityInt(1);
        var other = new object();

        // Act
        var result = entity.Equals(other);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void GetHashCode_ShouldReturnSameHash_WhenSameId_ForInt()
    {
        // Arrange
        var entity1 = new TestEntityInt(1);
        var entity2 = new TestEntityInt(1);

        // Act
        var hash1 = entity1.GetHashCode();
        var hash2 = entity2.GetHashCode();

        // Assert
        hash1.Should().Be(hash2);
    }

    [Fact]
    public void GetHashCode_ShouldReturnSameHash_WhenSameId_ForString()
    {
        // Arrange
        var entity1 = new TestEntityString("id");
        var entity2 = new TestEntityString("id");

        // Act
        var hash1 = entity1.GetHashCode();
        var hash2 = entity2.GetHashCode();

        // Assert
        hash1.Should().Be(hash2);
    }

    [Fact]
    public void GetHashCode_ShouldReturnDifferentHash_WhenDifferentIds_ForInt()
    {
        // Arrange
        var entity1 = new TestEntityInt(1);
        var entity2 = new TestEntityInt(2);

        // Act
        var hash1 = entity1.GetHashCode();
        var hash2 = entity2.GetHashCode();

        // Assert
        hash1.Should().NotBe(hash2);
    }

    [Fact]
    public void OperatorEquals_ShouldReturnTrue_WhenSameId()
    {
        // Arrange
        var entity1 = new TestEntityInt(1);
        var entity2 = new TestEntityInt(1);

        // Act
        var result = entity1 == entity2;

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void OperatorEquals_ShouldReturnFalse_WhenDifferentIds()
    {
        // Arrange
        var entity1 = new TestEntityInt(1);
        var entity2 = new TestEntityInt(2);

        // Act
        var result = entity1 == entity2;

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void OperatorEquals_ShouldReturnFalse_WhenOneIsNull()
    {
        // Arrange
        var entity = new TestEntityInt(1);

        // Act
        var result = entity == null;

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void OperatorEquals_ShouldReturnTrue_WhenBothNull()
    {
        // Arrange
        TestEntityInt? entity1 = null;
        TestEntityInt? entity2 = null;

        // Act
        var result = entity1 == entity2;

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void OperatorNotEquals_ShouldReturnFalse_WhenSameId()
    {
        // Arrange
        var entity1 = new TestEntityInt(1);
        var entity2 = new TestEntityInt(1);

        // Act
        var result = entity1 != entity2;

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void OperatorNotEquals_ShouldReturnTrue_WhenDifferentIds()
    {
        // Arrange
        var entity1 = new TestEntityInt(1);
        var entity2 = new TestEntityInt(2);

        // Act
        var result = entity1 != entity2;

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void OperatorNotEquals_ShouldReturnTrue_WhenOneIsNull()
    {
        // Arrange
        var entity = new TestEntityInt(1);

        // Act
        var result = entity != null;

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void OperatorNotEquals_ShouldReturnFalse_WhenBothNull()
    {
        // Arrange
        TestEntityInt? entity1 = null;
        TestEntityInt? entity2 = null;

        // Act
        var result = entity1 != entity2;

        // Assert
        result.Should().BeFalse();
    }

    private class TestEntityInt : Entity<int>
    {
        public TestEntityInt(int id) : base(id)
        {
        }
    }

    private class TestEntityString : Entity<string>
    {
        public TestEntityString(string id) : base(id)
        {
        }
    }

    private class DifferentEntity : Entity<int>
    {
        public DifferentEntity(int id) : base(id)
        {
        }
    }
}