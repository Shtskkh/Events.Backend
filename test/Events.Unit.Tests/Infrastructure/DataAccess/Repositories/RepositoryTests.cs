using Events.Domain.Shared;
using Events.Infrastructure.DataAccess.Repositories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace Events.Unit.Tests.Infrastructure.DataAccess.Repositories;

internal class TestEntity : Entity<int>
{
    public TestEntity(int id, string name) : base(id)
    {
        Name = name;
    }

    public string Name { get; set; }
}

internal class TestDbContext : DbContext
{
    public TestDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<TestEntity> TestEntities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<TestEntity>(entity =>
        {
            entity.HasKey(t => t.Id);
            entity.Property(t => t.Name).IsRequired();
        });
    }
}

public class RepositoryTests
{
    private readonly TestDbContext _context;
    private readonly Repository<TestEntity, int, TestDbContext> _repository;

    public RepositoryTests()
    {
        var options = new DbContextOptionsBuilder<TestDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        _context = new TestDbContext(options);
        _repository = new Repository<TestEntity, int, TestDbContext>(_context);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllEntities()
    {
        // Arrange
        var entity1 = new TestEntity(1, "Entity1");
        var entity2 = new TestEntity(2, "Entity2");
        await _repository.AddAsync(entity1);
        await _repository.AddAsync(entity2);

        // Act
        var result = _repository.GetAllAsync().ToList();

        // Assert
        result.Should().HaveCount(2);
        result.Should().ContainEquivalentOf(entity1);
        result.Should().ContainEquivalentOf(entity2);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnEntity_WhenExists()
    {
        // Arrange
        var entity = new TestEntity(1, "Entity");
        await _repository.AddAsync(entity);

        // Act
        var result = await _repository.GetByIdAsync(1);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(entity);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnNull_WhenNotExists()
    {
        // Act
        var result = await _repository.GetByIdAsync(999);

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public async Task IsExistsAsync_ShouldReturnTrue_WhenExists()
    {
        // Arrange
        var entity = new TestEntity(1, "Entity");
        await _repository.AddAsync(entity);

        // Act
        var exists = await _repository.IsExistsAsync(1);

        // Assert
        exists.Should().BeTrue();
    }

    [Fact]
    public async Task IsExistsAsync_ShouldReturnFalse_WhenNotExists()
    {
        // Act
        var exists = await _repository.IsExistsAsync(999);

        // Assert
        exists.Should().BeFalse();
    }

    [Fact]
    public async Task AddAsync_ShouldAddEntity()
    {
        // Arrange
        var entity = new TestEntity(1, "NewEntity");

        // Act
        await _repository.AddAsync(entity);
        var added = await _repository.GetByIdAsync(1);

        // Assert
        added.Should().NotBeNull();
        added.Should().BeEquivalentTo(entity);
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdateEntity()
    {
        // Arrange
        var entity = new TestEntity(1, "Original");
        await _repository.AddAsync(entity);
        entity.Name = "Updated";

        // Act
        await _repository.UpdateAsync(entity);
        var updated = await _repository.GetByIdAsync(1);

        // Assert
        updated.Should().NotBeNull();
        updated!.Name.Should().Be("Updated");
    }

    [Fact]
    public async Task UpdateAsync_ShouldThrow_WhenEntityNotAttached()
    {
        // Arrange
        var entity = new TestEntity(999, "Detached");

        // Act & Assert
        await Assert.ThrowsAsync<DbUpdateConcurrencyException>(() => _repository.UpdateAsync(entity));
    }

    [Fact]
    public async Task DeleteAsync_ShouldRemoveEntity()
    {
        // Arrange
        var entity = new TestEntity(1, "ToDelete");
        await _repository.AddAsync(entity);

        // Act
        await _repository.DeleteAsync(entity);
        var deleted = await _repository.GetByIdAsync(1);

        // Assert
        deleted.Should().BeNull();
    }

    [Fact]
    public async Task DeleteAsync_ShouldThrow_WhenEntityNotAttached()
    {
        // Arrange
        var entity = new TestEntity(999, "Detached");

        // Act & Assert
        await Assert.ThrowsAsync<DbUpdateConcurrencyException>(() => _repository.DeleteAsync(entity));
    }
}