using Ardalis.Specification;
using Events.Contracts.Equipment;
using Events.Domain.Aggregates.Equipment;

namespace Events.Application.Services.Features.Equipment.Specifications;

public class EquipmentFilterSpec : Specification<EquipmentItem>
{
    public EquipmentFilterSpec(EquipmentFilterDto filter)
    {
        if (!string.IsNullOrWhiteSpace(filter.InventoryNumber))
            Query.Where(e => e.InventoryNumber.Value.ToLower().Contains(filter.InventoryNumber.ToLower()));

        if (filter.EquipmentTypeId.HasValue)
            Query.Where(e => e.Type.Id == filter.EquipmentTypeId.Value);

        if (filter.PlaceId.HasValue)
            Query.Where(e => e.PlaceId == filter.PlaceId.Value);

        Query.OrderByDescending(e => e.CreatedAt);
        Query.Skip(filter.Size * (filter.Page - 1));
        Query.Take(filter.Size);

        Query.AsNoTracking();
    }
}