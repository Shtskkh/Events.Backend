using Events.Application.Services.Features.Locations.Repositories;
using Events.Domain.Aggregates.LocationAggregate.Factories.Locations;
using MediatR;

namespace Events.Application.Services.Features.Locations.Commands.CreateLocation;

/// <summary>
///     Handler создания локации.
/// </summary>
/// <param name="locationRepository">Репозиторий локаций.</param>
public class CreateLocationHandler(ILocationRepository locationRepository) : IRequestHandler<CreateLocationCommand, int>
{
    /// <inheritdoc />
    public async Task<int> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
    {
        var dto = request.NewLocation;

        var location = LocationFactory.Create(dto.Title, dto.Address);

        return await locationRepository.AddAsync(location, cancellationToken);
    }
}