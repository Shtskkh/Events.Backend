using Events.Domain.Aggregates.LocationAggregate;
using Events.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Events.Infrastructure.DataAccess.Context.Locations.Configurations;

/// <summary>
///     Конфигурация локации.
/// </summary>
public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.ToTable("Locations");

        builder.HasKey(l => l.Id);

        builder.Property(l => l.Id)
            .UseIdentityColumn()
            .ValueGeneratedOnAdd();

        builder.OwnsOne(l => l.Title)
            .Property(t => t.Value)
            .HasColumnName("Title")
            .HasMaxLength(DomainConstraints.Location.Title.MaxLength)
            .IsRequired();

        builder.OwnsOne(l => l.Address)
            .Property(a => a.Value)
            .HasColumnName("Address")
            .HasMaxLength(DomainConstraints.Location.Address.MaxLength)
            .IsRequired();

        builder.Property(l => l.CreatedAt)
            .IsRequired()
            .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Throw);

        builder.HasMany(l => l.Places)
            .WithOne()
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(l => l.UpdatedAt)
            .IsRequired();
    }
}