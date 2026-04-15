using Events.Domain.Shared;

namespace Events.Domain.Aggregates.Locations.Errors;

public static class LocationErrors
{
    public static Error NotFoundAny => new("Location.NotFoundAny", "Локации не найдены.");

    public static Error NotFoundById(int locationId)
    {
        return new Error("Location.NotFoundById", $"Локация с ID: {locationId} не найдена.");
    }
}