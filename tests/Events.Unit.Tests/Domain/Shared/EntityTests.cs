using Events.Domain.Shared;
using FluentAssertions;

namespace Events.Unit.Tests.Domain.Shared;

/// <summary>
///     Тесты для абстрактного класса Entity.
/// </summary>
public class EntityTests
{
    // Вспомогательные конкретные реализации для тестирования

    private sealed class TestEntity : Entity<Guid>
    {
        public TestEntity(Guid id) : base(id) { }
    }

    private sealed class AnotherEntity : Entity<Guid>
    {
        public AnotherEntity(Guid id) : base(id) { }
    }

    private sealed class IntEntity : Entity<int>
    {
        public IntEntity(int id) : base(id) { }
    }
    
    // Equals

    [Fact]
    public void Equals_SameId_ReturnsTrue()
    {
        // Arrange
        var id = Guid.NewGuid();
        var a = new TestEntity(id);
        var b = new TestEntity(id);

        // Act & Assert
        a.Equals(b).Should().BeTrue();
    }

    [Fact]
    public void Equals_DifferentId_ReturnsFalse()
    {
        // Arrange
        var a = new TestEntity(Guid.NewGuid());
        var b = new TestEntity(Guid.NewGuid());

        // Act & Assert
        a.Equals(b).Should().BeFalse();
    }

    [Fact]
    public void Equals_SameReference_ReturnsTrue()
    {
        // Arrange
        var a = new TestEntity(Guid.NewGuid());

        // Act & Assert
        a.Equals(a).Should().BeTrue();
    }

    [Fact]
    public void Equals_Null_ReturnsFalse()
    {
        // Arrange
        var a = new TestEntity(Guid.NewGuid());

        // Act & Assert
        a.Equals(null).Should().BeFalse();
    }

    [Fact]
    public void Equals_DifferentEntityType_SameId_ReturnsFalse()
    {
        // Arrange
        var id = Guid.NewGuid();
        var a = new TestEntity(id);
        var b = new AnotherEntity(id);

        // Act & Assert
        a.Equals(b).Should().BeFalse();
    }

    [Fact]
    public void Equals_DefaultId_ReturnsFalse()
    {
        // Arrange
        var a = new TestEntity(Guid.Empty);
        var b = new TestEntity(Guid.Empty);

        // Act & Assert
        a.Equals(b).Should().BeFalse();
    }
    
    // GetHashCode

    [Fact]
    public void GetHashCode_SameId_ReturnsSameHash()
    {
        // Arrange
        var id = Guid.NewGuid();
        var a = new TestEntity(id);
        var b = new TestEntity(id);

        // Act & Assert
        a.GetHashCode().Should().Be(b.GetHashCode());
    }

    [Fact]
    public void GetHashCode_DifferentId_ReturnsDifferentHash()
    {
        // Arrange
        var a = new TestEntity(Guid.NewGuid());
        var b = new TestEntity(Guid.NewGuid());

        // Act & Assert
        a.GetHashCode().Should().NotBe(b.GetHashCode());
    }
    
    // Операторы == и !=

    [Fact]
    public void EqualityOperator_SameId_ReturnsTrue()
    {
        // Arrange
        var id = Guid.NewGuid();
        var a = new TestEntity(id);
        var b = new TestEntity(id);

        // Act & Assert
        (a == b).Should().BeTrue();
    }

    [Fact]
    public void InequalityOperator_DifferentId_ReturnsTrue()
    {
        // Arrange
        var a = new TestEntity(Guid.NewGuid());
        var b = new TestEntity(Guid.NewGuid());

        // Act & Assert
        (a != b).Should().BeTrue();
    }

    [Fact]
    public void EqualityOperator_BothNull_ReturnsTrue()
    {
        // Arrange
        TestEntity? a = null;
        TestEntity? b = null;

        // Act & Assert
        (a == b).Should().BeTrue();
    }

    [Fact]
    public void EqualityOperator_OneNull_ReturnsFalse()
    {
        // Arrange
        var a = new TestEntity(Guid.NewGuid());
        TestEntity? b = null;

        // Act & Assert
        (a == b).Should().BeFalse();
    }
    
    // Id property

    [Fact]
    public void Id_ReturnsCorrectValue()
    {
        // Arrange
        var id = Guid.NewGuid();
        var entity = new TestEntity(id);

        // Act & Assert
        entity.Id.Should().Be(id);
    }

    [Fact]
    public void Id_IntKey_ReturnsCorrectValue()
    {
        // Arrange
        var entity = new IntEntity(99);

        // Act & Assert
        entity.Id.Should().Be(99);
    }
}
