using Events.Domain.Aggregates.Analytics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Events.Infrastructure.Analytics.Context.PageViews.Configurations;

/// <summary>
///     Конфигурация сущности посещения страницы.
/// </summary>
public class PageViewConfiguration : IEntityTypeConfiguration<PageView>
{
    public void Configure(EntityTypeBuilder<PageView> builder)
    {
        builder.ToTable("PageViews");

        builder.HasKey(pv => new { pv.EntityId, pv.ViewedAt });

        builder.Property(p => p.EntityType)
            .IsRequired();

        builder.Property(pv => pv.EntityId)
            .IsRequired();

        builder.Property(pv => pv.ViewedAt)
            .IsRequired();

        builder.Property(pv => pv.UserId);
    }
}