using Events.Application.Services.Features.Places.Repositories;
using Events.Application.Services.Features.Places.Specifications;
using Events.Application.Services.Shared;
using Events.Domain.Aggregates.LocationAggregate;
using MediatR;

namespace Events.Application.Services.Features.Places.Commands.Update;

/// <inheritdoc />
public sealed class UpdatePlaceHandler(IPlaceRepository placeRepository, IRepository<PlaceType> placeTypeRepository)
    : IRequestHandler<UpdatePlaceCommand>
{
    /// <inheritdoc />
    public async Task Handle(UpdatePlaceCommand request, CancellationToken cancellationToken)
    {
        var spec = new PlaceSpec().WithId(request.PlaceId);
        var place = await placeRepository.GetAsync(spec, cancellationToken);

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