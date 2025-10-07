using Events.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Events.Infrastructure.DataAccess.Context.Bookings.Configurations;

public class BookingConfigurations : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(x => x.Start)
            .IsRequired();
        
        builder.Property(x => x.End)
            .IsRequired();
        
        builder.Property(x => x.ParticipantsCount)
            .IsRequired();

        builder.Property(x => x.Note);
        
        builder.Property(x => x.CreatedAt)
            .IsRequired();
        
        builder.HasOne(x => x.Event)
            .WithMany(x => x.Bookings)
            .HasForeignKey(x => x.EventId);
        
        builder.HasOne(x => x.Place)
            .WithMany(x => x.Bookings)
            .HasForeignKey(x => x.PlaceId);
    }
}