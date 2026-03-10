using AutoMapper;
using Events.Application.Services.Features.Locations.Repositories;
using Events.Domain.Aggregates.LocationAggregate.Factories.Places;
using MediatR;

namespace Events.Application.Services.Features.Locations.Commands.CreatePlace;

/// <summary>
///     Handler создания помещения.
/// </summary>
/// <param name="placeTypeRepository">Репозиторий типов помещений.</param>
/// <param name="mapper">Маппер.</param>
public class CreatePlaceHandler(
    ILocationRepository locationRepository,
    IPlaceTypeRepository placeTypeRepository,
    IMapper mapper)
    : IRequestHandler<CreatePlaceCommand, int>
{
    /// <inheritdoc />
    public async Task<int> Handle(CreatePlaceCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;
        var location = await locationRepository.GetByIdAsync(request.LocationId, cancellationToken);
        var placeType = await placeTypeRepository.GetByIdAsync(dto.Type, cancellationToken);

        var place = new PlaceFactory().Create(dto.Number, placeType, dto.Title);
        location.AddPlace(place);

        await locationRepository.UpdateAsync(location, cancellationToken);

        return place.Id;
    }
}