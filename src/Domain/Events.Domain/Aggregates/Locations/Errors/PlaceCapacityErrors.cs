using Events.Domain.Shared;

namespace Events.Domain.Aggregates.Locations.Errors;

public static class PlaceCapacityErrors
{
    public static Error LessOrEqualZero => new("PlaceCapacity.LessOrEqualZero", "Вместимость помещения не может быть меньше или равна 0.");
}
