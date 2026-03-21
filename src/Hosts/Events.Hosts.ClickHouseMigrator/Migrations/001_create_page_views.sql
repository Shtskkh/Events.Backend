CREATE TABLE IF NOT EXISTS EventsAnalytics.PageViews
(
    EntityType LowCardinality(String),
    EntityId   UUID,
    UserId     Nullable(UUID),
    ViewedAt   DateTime64(3, 'UTC')
)
ENGINE = MergeTree()
ORDER BY (EntityType, EntityId, ViewedAt)
PARTITION BY toYYYYMM(ViewedAt);