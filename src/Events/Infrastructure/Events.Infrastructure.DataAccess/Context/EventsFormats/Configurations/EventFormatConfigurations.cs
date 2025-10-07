using Events.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Events.Infrastructure.DataAccess.Context.EventsFormats.Configurations;

public class EventFormatConfigurations : IEntityTypeConfiguration<EventFormat>
{
    public void Configure(EntityTypeBuilder<EventFormat> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Title)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.HasMany(e => e.Events)
            .WithOne(e => e.EventFormat)
            .HasForeignKey(e => e.EventFormatId);
    }
}