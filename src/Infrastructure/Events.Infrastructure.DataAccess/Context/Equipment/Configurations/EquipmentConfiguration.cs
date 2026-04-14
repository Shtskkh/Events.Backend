using Events.Domain.Aggregates.Equipment;
using Events.Domain.Aggregates.Equipment.Constraints;
using Events.Domain.Aggregates.Locations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Events.Infrastructure.DataAccess.Context.Equipment.Configurations;

/// <summary>
///     Конфигурация оборудования.
/// </summary>
public class EquipmentConfiguration : IEntityTypeConfiguration<EquipmentItem>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<EquipmentItem> builder)
    {
        builder.ToTable("Equipment");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .UseIdentityColumn()
            .ValueGeneratedOnAdd();

        builder.OwnsOne(e => e.Title)
            .Property(t => t.Value)
            .HasColumnName("Title")
            .HasMaxLength(EquipmentConstraints.MaxLength)
            .IsRequired();

        builder.OwnsOne(e => e.InventoryNumber, ownerBuilder =>
        {
            ownerBuilder.Property(e => e.Value)
                .HasColumnName("InventoryNumber")
                .HasMaxLength(EquipmentConstraints.InventoryNumber.MaxLength)
                .IsRequired();

            ownerBuilder.HasIndex(e => e.Value).IsUnique();
        });

        builder.HasOne(e => e.Type)
            .WithMany()
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.Navigation(e => e.Type)
            .AutoInclude();

        builder.HasOne<Place>()
            .WithMany()
            .HasForeignKey(e => e.PlaceId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(e => e.CreatedAt)
            .IsRequired()
            .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Throw);

        builder.Property(e => e.UpdatedAt)
            .IsRequired();
    }
}