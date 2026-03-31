using Events.Domain.Aggregates.LocationAggregate;
using Events.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Events.Infrastructure.DataAccess.Context.Equipment.Configurations;

/// <summary>
///     Конфигурация оборудования.
/// </summary>
public class EquipmentConfiguration : IEntityTypeConfiguration<Domain.Aggregates.EquipmentAggregate.Equipment>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<Domain.Aggregates.EquipmentAggregate.Equipment> builder)
    {
        builder.ToTable("Equipment");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .UseIdentityColumn()
            .ValueGeneratedOnAdd();

        builder.OwnsOne(e => e.Title)
            .Property(t => t.Value)
            .HasColumnName("Title")
            .HasMaxLength(DomainConstraints.Equipment.MaxLength)
            .IsRequired();

        builder.OwnsOne(e => e.InventoryNumber, ownerBuilder =>
        {
            ownerBuilder.Property(e => e.Value)
                .HasColumnName("InventoryNumber")
                .HasMaxLength(DomainConstraints.Equipment.InventoryNumber.MaxLength)
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
    }
}