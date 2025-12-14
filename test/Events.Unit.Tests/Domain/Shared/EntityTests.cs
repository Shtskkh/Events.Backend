using Events.Domain.Shared;
using FluentAssertions;

namespace Events.Unit.Tests.Domain.Shared;

internal class TestEntityGuid : Entity<Guid>
{
    public TestEntityGuid(Guid id) : base(id)
    {
    }
}

internal class TestEntityInt : Entity<int>
{
    public TestEntityInt(int id) : base(id)
    {
    }
}

public class EntityTests
{
    [Fact]
    public void GetId()
    {
        var guid = Guid.NewGuid();
        var intId = 0;
        var entity1 = new TestEntityGuid(guid);
        var entity2 = new TestEntityInt(intId);

        entity1.Id.Should().Be(guid);
        entity2.Id.Should().Be(intId);
    }

    [Fact]
    public void Equals_SameId_ShouldBeTrue()
    {
        var id = Guid.NewGuid();
        var entity1 = new TestEntityGuid(id);
        var entity2 = new TestEntityGuid(id);

        entity1.Equals(entity2).Should().BeTrue();
        (entity1 == entity2).Should().BeTrue();
        (entity1 != entity2).Should().BeFalse();
    }

    [Fact]
    public void Equals_DifferentId_ShouldBeFalse()
    {
        var entity1 = new TestEntityGuid(Guid.NewGuid());
        var entity2 = new TestEntityGuid(Guid.NewGuid());

        entity1.Equals(entity2).Should().BeFalse();
        (entity1 == entity2).Should().BeFalse();
        (entity1 != entity2).Should().BeTrue();
    }

    [Fact]
    public void Equals_DifferentType_ShouldBeFalse()
    {
        var entity1 = new TestEntityGuid(Guid.NewGuid());
        var entity2 = new TestEntityInt(1);

        entity1.Equals(entity2).Should().BeFalse();
    }

    [Fact]
    public void GetHashCode_SameId_ShouldBeEqual()
    {
        var id = Guid.NewGuid();
        var entity1 = new TestEntityGuid(id);
        var entity2 = new TestEntityGuid(id);

        entity1.GetHashCode().Should().Be(entity2.GetHashCode());
    }

    [Fact]
    public void GetHashCode_DifferentId_ShouldBeNotEqual()
    {
        var entity1 = new TestEntityGuid(Guid.NewGuid());
        var entity2 = new TestEntityGuid(Guid.NewGuid());
        entity1.GetHashCode().Should().NotBe(entity2.GetHashCode());
    }

    [Fact]
    public void IsTransient_DefaultId_ShouldBeTrue()
    {
        var entity1 = new TestEntityGuid(default);
        var entity2 = new TestEntityInt(default);

        entity1.IsTransient().Should().BeTrue();
        entity2.IsTransient().Should().BeTrue();
    }

    [Fact]
    public void IsTransient_AssignedId_ShouldReturnFalse()
    {
        var entity1 = new TestEntityGuid(Guid.NewGuid());
        var entity2 = new TestEntityInt(1);

        entity1.IsTransient().Should().BeFalse();
        entity2.IsTransient().Should().BeFalse();
    }
}