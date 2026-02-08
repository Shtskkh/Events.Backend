using Events.Domain.Aggregates.EventAggregate;
using Events.Domain.Aggregates.EventAggregate.ValueObjects;
using Events.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Events.Infrastructure.DataAccess.Context.Events.Configurations;

public class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Title)
            .HasConversion(
                v => v.Value,
                v => new EventTitle(v)
            )
            .HasMaxLength(DomainConstraints.Event.Title.MaxLength)
            .IsRequired();

        builder.Property(e => e.Announcement)
            .HasConversion(
                v => v.Value,
                v => new EventAnnouncement(v))
            .HasMaxLength(DomainConstraints.Event.Announcement.MaxLength)
            .IsRequired();

        builder.Property(e => e.Description)
            .HasConversion(
                v => v.Value,
                v => new EventDescription(v))
            .HasMaxLength(DomainConstraints.Event.Description.MaxLength)
            .IsRequired();

        builder.Property(e => e.StartDateTime)
            .IsRequired();

        builder.Property(e => e.EndDateTime)
            .IsRequired();

        builder.Property(e => e.PreviewFilename);
    }
}