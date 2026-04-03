using Events.Domain.Aggregates.AnalyticsAggregate;
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

        builder.HasNoKey();

        builder.Property(e => e.EntityType)
            .IsRequired();

        builder.Property(e => e.EntityId)
            .IsRequired();

        builder.Property(e => e.ViewedAt)
            .IsRequired();

        builder.Property(e => e.UserId);
    }
}