using Events.Domain.Aggregates.Events.ValueObjects;
using Events.Domain.Shared;

namespace Events.Domain.Aggregates.Events.Errors;

public static class EventAnnouncementErrors
{
    public static Error GreaterThanMaxLength =>
        new("EventAnnouncement.GreaterThanMaxLength",
            $"Анонс мероприятия длиннее максимальной длины в {Announcement.MaxLength} символ(-ов).");
}