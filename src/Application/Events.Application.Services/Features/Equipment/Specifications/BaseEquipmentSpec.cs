using Ardalis.Specification;

namespace Events.Application.Services.Features.Equipment.Specifications;

/// <summary>
///     Базовая спецификация для оборудования.
/// </summary>
public abstract class BaseEquipmentSpec : Specification<Domain.Aggregates.EquipmentAggregate.Equipment>
{
    public new BaseEquipmentSpec AsNoTracking()
    {
        Query.AsNoTracking();
        return this;
    }
}