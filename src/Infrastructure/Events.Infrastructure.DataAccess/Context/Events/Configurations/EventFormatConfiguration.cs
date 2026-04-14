using Events.Domain.Aggregates.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Events.Infrastructure.DataAccess.Context.Events.Configurations;

/// <summary>
///     Конфигурация форматов мероприятий.
/// </summary>
public class EventFormatConfiguration : IEntityTypeConfiguration<EventFormat>
{
    public void Configure(EntityTypeBuilder<EventFormat> builder)
    {
        builder.ToTable("EventsFormats");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title).IsRequired();

        builder.HasData(EventFormat.Online);
        builder.HasData(EventFormat.Offline);
        builder.HasData(EventFormat.Hybrid);
    }
}