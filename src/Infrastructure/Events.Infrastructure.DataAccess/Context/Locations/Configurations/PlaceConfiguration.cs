using Events.Domain.Aggregates.Locations;
using Events.Domain.Aggregates.Locations.ValueObjects.Places;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Events.Infrastructure.DataAccess.Context.Locations.Configurations;

/// <summary>
///     Конфигурация помещений.
/// </summary>
public class PlaceConfiguration : IEntityTypeConfiguration<Place>
{
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
            .HasMaxLength(PlaceNumber.MaxLength)
            .IsRequired();

        builder.OwnsOne(p => p.Capacity)
            .Property(n => n.Value)
            .HasColumnName("Capacity")
            .IsRequired();

        builder.OwnsOne(p => p.Title)
            .Property(t => t.Value)
            .HasColumnName("Title")
            .HasMaxLength(PlaceTitle.MaxLength);

        builder.HasOne(p => p.Type)
            .WithMany()
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.OwnsMany(l => l.Photos, photoBuilder =>
        {
            photoBuilder.ToTable("PlacesPhotos");

            photoBuilder.Property<int>("Id");
            photoBuilder.HasKey("Id");

            photoBuilder.Property(p => p.Filename)
                .HasColumnName("Filename")
                .IsRequired();

            photoBuilder.Property(p => p.Order)
                .HasColumnName("Order")
                .IsRequired();

            photoBuilder.WithOwner().HasForeignKey("PlaceId");
        });

        builder.HasOne<Location>()
            .WithMany(l => l.Places)
            .HasForeignKey(p => p.LocationId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(p => p.CreatedAt)
            .IsRequired()
            .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Throw);

        builder.Property(p => p.UpdatedAt)
            .IsRequired();

        builder.Navigation(e => e.Type)
            .AutoInclude();
    }
}