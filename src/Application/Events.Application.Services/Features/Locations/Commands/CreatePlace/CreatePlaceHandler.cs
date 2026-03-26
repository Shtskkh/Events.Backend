using Amazon.S3;
using Amazon.S3.Model;
using Events.Application.Services.Features.Files;
using Events.Application.Services.Features.Locations.Repositories;
using Events.Application.Services.Features.Locations.Specifications;
using Events.Domain.Aggregates.LocationAggregate.Factories.Places;
using MediatR;

namespace Events.Application.Services.Features.Locations.Commands.CreatePlace;

/// <inheritdoc />
public class CreatePlaceHandler(
    ILocationRepository locationRepository,
    IPlaceTypeRepository placeTypeRepository,
    IFileStorageService fileStorageService)
    : IRequestHandler<CreatePlaceCommand, int>
{
    /// <inheritdoc />
    public async Task<int> Handle(CreatePlaceCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;

        var spec = new LocationByIdSpec(request.LocationId).WithPlaces();
        var location = await locationRepository.GetAsync(spec, cancellationToken);
        var placeType = await placeTypeRepository.GetByIdAsync(dto.Type, cancellationToken);

        var place = PlaceFactory.Create(dto.Number, dto.Capacity, placeType, dto.Title);

        var uploadedFilenames = new List<string>();
        try
        {
            if (dto.Photos is { Count: > 0 })
                foreach (var photo in dto.Photos)
                {
                    var filename = $"{Guid.NewGuid()}{Path.GetExtension(photo.FileName)}";

                    await using var stream = photo.OpenReadStream();
                    var putObjectRequest = new PutObjectRequest
                    {
                        BucketName = S3Buckets.PlacesPhotos,
                        Key = filename,
                        ContentType = photo.ContentType,
                        InputStream = stream,
                        CannedACL = S3CannedACL.PublicRead
                    };

                    await fileStorageService.PutObjectAsync(putObjectRequest, cancellationToken);

                    uploadedFilenames.Add(filename);
                    location.AddPhoto(filename);
                }

            location.AddPlace(place);
            await locationRepository.UpdateAsync(location, cancellationToken);
        }
        catch (Exception)
        {
            await fileStorageService.SafeDeleteObjectsAsync(S3Buckets.PlacesPhotos, uploadedFilenames,
                cancellationToken);
            throw;
        }

        return place.Id;
    }
}