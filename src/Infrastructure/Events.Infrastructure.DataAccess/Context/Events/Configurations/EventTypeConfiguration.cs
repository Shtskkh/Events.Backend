using Events.Domain.Aggregates.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Events.Infrastructure.DataAccess.Context.Events.Configurations;

/// <summary>
///     Конфигурация типов мероприятий.
/// </summary>
public class EventTypeConfiguration : IEntityTypeConfiguration<EventType>
{
    public void Configure(EntityTypeBuilder<EventType> builder)
    {
        builder.ToTable("EventsTypes");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Title)
            .HasMaxLength(EventType.MaxTitleLength)
            .IsRequired();

        builder.HasData(EventType.Concert);
        builder.HasData(EventType.Conference);
        builder.HasData(EventType.Meetup);
    }
}