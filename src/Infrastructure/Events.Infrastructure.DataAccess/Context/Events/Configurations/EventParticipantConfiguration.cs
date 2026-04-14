using Events.Domain.Aggregates.Events.ValueObjects;
using Events.Domain.Aggregates.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Events.Infrastructure.DataAccess.Context.Events.Configurations;

/// <inheritdoc />
public class EventParticipantConfiguration : IEntityTypeConfiguration<EventParticipant>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<EventParticipant> builder)
    {
        builder.ToTable("Participants");

        builder.HasKey(e => new { e.EventId, e.UserId });

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(e => e.RegistrationTime)
            .IsRequired();
    }
}