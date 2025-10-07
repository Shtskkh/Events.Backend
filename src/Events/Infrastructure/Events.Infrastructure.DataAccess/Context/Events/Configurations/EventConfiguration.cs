using Events.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Events.Infrastructure.DataAccess.Context.Events.Configurations;

public class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Title)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(x => x.Annoucement)
            .HasMaxLength(200)
            .IsRequired();
        
        builder.Property(x => x.Description)
            .HasMaxLength(1000)
            .IsRequired();
        
        builder.Property(x => x.Duration)
            .IsRequired();
        
        builder.Property(x => x.MaxParticipants)
            .IsRequired();
        
        builder.Property(x => x.PreviewPhoto)
            .IsRequired();
        
        builder.Property(x => x.CreatedAt)
            .IsRequired();
        
        builder.Property(x => x.IsPublic)
            .IsRequired();
        
        builder.Property(x => x.NeedsRegistration)
            .IsRequired();
        
        builder.HasOne(x => x.EventType)
            .WithMany(x => x.Events)
            .HasForeignKey(x => x.EventTypeId);
        
        builder.HasOne(x => x.EventFormat)
            .WithMany(x => x.Events)
            .HasForeignKey(x => x.EventFormatId);
        
        builder.HasOne(x => x.Organizer)
            .WithMany(x => x.EventsOrganized)
            .HasForeignKey(x => x.OrganizerId);

        builder.HasMany(x => x.Tags)
            .WithMany(x => x.Events);
        
        builder.HasMany(x => x.Posts)
            .WithOne(x => x.Event)
            .HasForeignKey(x => x.EventId);
        
        builder.HasMany(x => x.Participants)
            .WithOne(x => x.Event)
            .HasForeignKey(x => x.EventId);
        
        builder.HasMany(x => x.OnlineSessions)
            .WithOne(x => x.Event)
            .HasForeignKey(x => x.EventId);
        
        builder.HasMany(x => x.Bookings)
            .WithOne(x => x.Event)
            .HasForeignKey(x => x.EventId);
    }
}