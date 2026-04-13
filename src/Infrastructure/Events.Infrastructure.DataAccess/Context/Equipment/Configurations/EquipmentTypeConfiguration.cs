using Events.Domain.Aggregates.Equipment;
using Events.Domain.Aggregates.Equipment.Constraints;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Events.Infrastructure.DataAccess.Context.Equipment.Configurations;

/// <summary>
///     Конфигурация типов оборудования.
/// </summary>
public class EquipmentTypeConfiguration : IEntityTypeConfiguration<EquipmentType>
{
    public void Configure(EntityTypeBuilder<EquipmentType> builder)
    {
        builder.ToTable("EquipmentTypes");

        builder.HasKey(e => e.Id);

        builder.Property(t => t.Id)
            .UseIdentityColumn()
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Title)
            .HasMaxLength(EquipmentConstraints.Type.MaxLength)
            .IsRequired();

        builder.HasData(EquipmentType.Projector);
        builder.HasData(EquipmentType.ElectronicBoard);
        builder.HasData(EquipmentType.Tv);
        builder.HasData(EquipmentType.Pc);
    }
}