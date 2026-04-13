using Amazon.S3;
using Amazon.S3.Model;
using Events.Application.Services.Features.Files;
using Events.Application.Services.Features.Locations.Specifications;
using Events.Application.Services.Shared;
using Events.Domain.Aggregates.LocationAggregate;
using Events.Domain.Aggregates.LocationAggregate.Factories.Places;
using MediatR;

namespace Events.Application.Services.Features.Places.Commands.Create;

/// <inheritdoc />
public sealed class CreatePlaceHandler(
    IRepository<Location> locationRepository,
    IRepository<PlaceType> placeTypeRepository,
    IFileStorageService fileStorageService)
    : IRequestHandler<CreatePlaceCommand, int>
{
    /// <inheritdoc />
    public async Task<int> Handle(CreatePlaceCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;

        var spec = new LocationSpec().WithId(request.LocationId).IncludePlaces();
        var location = await locationRepository.FirstOrDefaultAsync(spec, cancellationToken);
        var placeType = await placeTypeRepository.GetByIdAsync(dto.Type, cancellationToken);

        var place = PlaceFactory.Create(dto.Number, dto.Capacity, placeType, request.LocationId, dto.Title);

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
                    place.AddPhoto(filename);
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