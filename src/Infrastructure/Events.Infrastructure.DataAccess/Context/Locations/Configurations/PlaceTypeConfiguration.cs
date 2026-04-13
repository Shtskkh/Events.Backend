using Events.Domain.Aggregates.Locations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Events.Infrastructure.DataAccess.Context.Locations.Configurations;

/// <summary>
///     Конфигурация типа помещения.
/// </summary>
public class PlaceTypeConfiguration : IEntityTypeConfiguration<PlaceType>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<PlaceType> builder)
    {
        builder.ToTable("PlacesTypes");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
            .UseIdentityColumn()
            .ValueGeneratedOnAdd();

        builder.Property(t => t.Title)
            .IsRequired();

        builder.HasData(PlaceType.Coworking);
        builder.HasData(PlaceType.Conference);
        builder.HasData(PlaceType.Audience);
    }
}