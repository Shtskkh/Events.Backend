using Events.Application.Services.Shared;
using Events.Domain.Aggregates.Locations;
using MediatR;

namespace Events.Application.Services.Features.Places.Commands.Update;

/// <inheritdoc />
public sealed class UpdatePlaceHandler(IRepository<Place> placeRepository, IRepository<PlaceType> placeTypeRepository)
    : IRequestHandler<UpdatePlaceCommand>
{
    /// <inheritdoc />
    public async Task Handle(UpdatePlaceCommand request, CancellationToken cancellationToken)
    {
        var place = await placeRepository.GetByIdAsync(request.PlaceId, cancellationToken);

        var dto = request.UpdateDto;

        if (dto.Capacity.HasValue)
            place.ChangeCapacity(dto.Capacity.Value);

        if (dto.Type != null)
        {
            var type = await placeTypeRepository.GetByIdAsync(dto.Type.Value, cancellationToken);
            place.ChangeType(type);
        }

        if (dto.Title != null)
            place.ChangeTitle(dto.Title);

        await placeRepository.UpdateAsync(place, cancellationToken);
    }
}