using Events.Domain.Aggregates.EventAggregate;
using Events.Domain.Aggregates.LocationAggregate;
using Events.Domain.Aggregates.UserAggregate;
using Events.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Events.Infrastructure.DataAccess.Context.Events.Configurations;

/// <summary>
///     Конфигурация сущности мероприятия.
/// </summary>
public class EventConfiguration : IEntityTypeConfiguration<Event>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.ToTable("Events");

        builder.HasKey(e => e.Id);

        builder.OwnsOne(e => e.Title)
            .Property(t => t.Value)
            .HasColumnName("Title")
            .HasMaxLength(DomainConstraints.Event.Title.MaxLength)
            .IsRequired();

        builder
            .OwnsOne(e => e.Announcement)
            .Property(a => a.Value)
            .HasColumnName("Announcement")
            .HasMaxLength(DomainConstraints.Event.Announcement.MaxLength)
            .IsRequired();

        builder
            .OwnsOne(e => e.Description)
            .Property(e => e.Value)
            .HasColumnName("Description")
            .HasMaxLength(DomainConstraints.Event.Description.MaxLength)
            .IsRequired();

        builder.Property(e => e.StartDateTime)
            .IsRequired();

        builder.Property(e => e.EndDateTime)
            .IsRequired();

        builder.Property(e => e.PreviewFilename);

        builder.Property(e => e.PlaceholderFilename);

        builder.Property(e => e.NeedsRegistration)
            .IsRequired();

        builder.Property(e => e.MaxParticipants);

        builder.HasOne(e => e.Type)
            .WithMany()
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.Navigation(e => e.Type).AutoInclude();

        builder.HasOne(e => e.Format)
            .WithMany()
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.Navigation(e => e.Format).AutoInclude();

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Place>()
            .WithMany()
            .HasForeignKey(e => e.PlaceId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(e => e.Participants)
            .WithOne()
            .HasForeignKey(e => e.EventId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(e => e.CreatedAt)
            .IsRequired()
            .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Throw);

        builder.Property(e => e.UpdatedAt)
            .IsRequired();
    }
}