using Events.Domain.Aggregates.LocationAggregate;
using Events.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Events.Infrastructure.DataAccess.Context.Locations.Configurations;

/// <summary>
///     Конфигурация помещений.
/// </summary>
public class PlaceConfiguration : IEntityTypeConfiguration<Place>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<Place> builder)
    {
        builder.ToTable("Places");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .UseIdentityColumn()
            .ValueGeneratedOnAdd();

        builder.OwnsOne(p => p.Number)
            .Property(n => n.Value)
            .HasColumnName("Number")
            .HasMaxLength(DomainConstraints.Place.Number.MaxLength)
            .IsRequired();

        builder.OwnsOne(p => p.Title)
            .Property(t => t.Value)
            .HasColumnName("Title")
            .HasMaxLength(DomainConstraints.Place.Title.MaxLength);

        builder.HasOne(p => p.Type)
            .WithMany()
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(p => p.CreatedAt)
            .IsRequired()
            .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Throw);

        builder.Property(p => p.UpdatedAt)
            .IsRequired();

        builder.Navigation(e => e.Type)
            .AutoInclude();
    }
}