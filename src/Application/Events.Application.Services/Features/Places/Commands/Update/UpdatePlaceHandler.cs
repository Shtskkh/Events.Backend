using Amazon.S3;
using Amazon.S3.Model;
using Events.Application.Services.Features.Files;
using Events.Application.Services.Shared;
using Events.Contracts.Photos;
using Events.Domain.Aggregates.Locations;
using Events.Domain.Aggregates.Locations.Errors;
using Events.Domain.Exceptions;
using Events.Domain.Shared.Errors;
using Events.Domain.Shared.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Events.Application.Services.Features.Places.Commands.Update;

public sealed class UpdatePlaceHandler(
    IRepository<Place> placeRepository,
    IRepository<PlaceType> placeTypeRepository,
    IFileStorageService fileStorageService)
    : IRequestHandler<UpdatePlaceCommand>
{
    public async Task Handle(UpdatePlaceCommand request, CancellationToken cancellationToken)
    {
        var place = await placeRepository.GetByIdAsync(request.PlaceId, cancellationToken);

        if (place == null)
            throw new NotFoundException(PlaceErrors.NotFoundById(request.PlaceId));

        var dto = request.UpdateDto;

        if (dto.Capacity.HasValue)
            place.ChangeCapacity(dto.Capacity.Value);

        if (dto.Type.HasValue)
        {
            var type = await placeTypeRepository.GetByIdAsync(dto.Type.Value, cancellationToken);
            if (type == null)
                throw new NotFoundException(PlaceErrors.NotFoundById(dto.Type.Value));

            place.ChangeType(type);
        }

        if (!string.IsNullOrWhiteSpace(dto.Title))
            place.ChangeTitle(dto.Title);

        if (dto.Photos != null)
            await UpdatePlacePhotosAsync(place, dto.Photos, cancellationToken);

        await placeRepository.UpdateAsync(place, cancellationToken);
    }

    private async Task UpdatePlacePhotosAsync(
        Place place,
        IReadOnlyCollection<PhotoEntryDto> photosEntry,
        CancellationToken cancellationToken)
    {
        var resolvedEntries = new List<PhotoEntry>(photosEntry.Count);

        foreach (var entry in photosEntry)
            if (entry.NewFile != null)
            {
                var filename = await UploadNewPhotoAsync(entry.NewFile, cancellationToken);
                resolvedEntries.Add(new PhotoEntry(filename, true));
            }
            else if (!string.IsNullOrWhiteSpace(entry.ExistingFilename))
            {
                resolvedEntries.Add(new PhotoEntry(entry.ExistingFilename, false));
            }
            else
            {
                throw new DomainException(PhotoErrors.InvalidEntry);
            }

        var toDelete = place.SyncPhotos(resolvedEntries);

        if (toDelete.Count > 0)
            await fileStorageService.SafeDeleteObjectsAsync(S3Buckets.PlacesPhotos, toDelete, cancellationToken);
    }

    private async Task<string> UploadNewPhotoAsync(IFormFile file, CancellationToken cancellationToken)
    {
        var filename = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

        await using var stream = file.OpenReadStream();
        await fileStorageService.PutObjectAsync(new PutObjectRequest
        {
            BucketName = S3Buckets.PlacesPhotos,
            Key = filename,
            ContentType = file.ContentType,
            InputStream = stream,
            CannedACL = S3CannedACL.PublicRead
        }, cancellationToken);

        return filename;
    }
}