using Events.Domain.Aggregates.EquipmentAggregate.ValueObjects;

namespace Events.Domain.Aggregates.EquipmentAggregate.Factories;

/// <summary>
///     Фабрика оборудования.
/// </summary>
public static class EquipmentFactory
{
    public static Equipment Create(string title, EquipmentType type, int? placeId = null)
    {
        var titleVo = new EquipmentTitle(title);

        return new Equipment(default, titleVo, type, placeId);
    }
}