using Events.Domain.Aggregates.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Events.Infrastructure.DataAccess.Context.Events.Configurations;

public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.ToTable("Tags");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Value)
            .HasMaxLength(Tag.MaxLength)
            .IsRequired();
    }
}