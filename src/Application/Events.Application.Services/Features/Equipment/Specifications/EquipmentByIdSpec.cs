using Ardalis.Specification;

namespace Events.Application.Services.Features.Equipment.Specifications;

public class EquipmentByIdSpec : BaseEquipmentSpec
{
    public EquipmentByIdSpec(int id)
    {
        Query.Where(e => e.Id == id);
    }
}