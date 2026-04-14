using Amazon.S3;
using Amazon.S3.Model;
using Events.Application.Services.Features.Files;
using Events.Application.Services.Features.Locations.Specifications;
using Events.Application.Services.Shared;
using Events.Domain.Aggregates.Locations;
using Events.Domain.Aggregates.Locations.Errors;
using Events.Domain.Aggregates.Locations.Factories.Places;
using Events.Domain.Exceptions;
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

        var locationByIdSpec = new LocationByIdSpec(request.LocationId).IncludePlaces().AsNoTracking();
        var location = await locationRepository.FirstOrDefaultAsync(locationByIdSpec, cancellationToken);

        if (location == null)
            throw new NotFoundException(LocationErrorMessages.NotFoundById(request.LocationId));

        var placeType = await placeTypeRepository.GetByIdAsync(dto.Type, cancellationToken);

        if (placeType == null)
            throw new NotFoundException(PlaceErrorMessages.Type.NotFoundById(dto.Type));

        var place = PlaceFactory.Create(dto.Number, dto.Capacity, placeType, request.LocationId, dto.Title);

        var uploadedFilenames = new List<string>(dto.Photos?.Count ?? 0);
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
            await fileStorageService.SafeDeleteObjectsAsync(
                S3Buckets.PlacesPhotos,
                uploadedFilenames,
                cancellationToken);
            throw;
        }

        return place.Id;
    }
}