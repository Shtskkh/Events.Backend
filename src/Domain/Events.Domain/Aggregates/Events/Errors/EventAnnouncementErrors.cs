using Events.Domain.Shared;

namespace Events.Domain.Aggregates.Events.Errors;

public static class EventAnnouncementErrors
{
    public static Error GreaterThanMaxLength(int max)
    {
        return new Error("EventAnnouncement.GreaterThanMaxLength",
            $"Анонс мероприятия длиннее максимальной длины в {max} символ(-ов).");
    }
}