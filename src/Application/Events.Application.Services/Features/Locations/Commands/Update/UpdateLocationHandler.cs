using Amazon.S3;
using Amazon.S3.Model;
using Events.Application.Services.Features.Files;
using Events.Application.Services.Features.Locations.Specifications;
using Events.Application.Services.Shared;
using Events.Contracts.Photos;
using Events.Domain.Aggregates.Locations;
using Events.Domain.Aggregates.Locations.Errors;
using Events.Domain.Exceptions;
using Events.Domain.Shared.Errors;
using Events.Domain.Shared.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Events.Application.Services.Features.Locations.Commands.Update;

public sealed class UpdateLocationHandler(
    IRepository<Location> locationRepository,
    IFileStorageService fileStorageService)
    : IRequestHandler<UpdateLocationCommand>
{
    public async Task Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
    {
        var locationByIdSpec = new LocationByIdSpec(request.LocationId).IncludePhotos();
        var location = await locationRepository.FirstOrDefaultAsync(locationByIdSpec, cancellationToken);

        if (location == null)
            throw new NotFoundException(LocationErrors.NotFoundById(request.LocationId));

        var dto = request.UpdateDto;

        if (!string.IsNullOrWhiteSpace(dto.Title))
            location.ChangeTitle(dto.Title);

        if (!string.IsNullOrWhiteSpace(dto.Address))
            location.ChangeAddress(dto.Address);

        if (dto.Photos != null)
            await UpdateLocationPhotosAsync(location, dto.Photos, cancellationToken);

        await locationRepository.UpdateAsync(location, cancellationToken);
    }

    private async Task UpdateLocationPhotosAsync(
        Location location,
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

        var toDelete = location.SyncPhotos(resolvedEntries);

        if (toDelete.Count > 0)
            await fileStorageService.SafeDeleteObjectsAsync(S3Buckets.LocationsPhotos, toDelete, cancellationToken);
    }

    private async Task<string> UploadNewPhotoAsync(IFormFile file, CancellationToken cancellationToken)
    {
        var filename = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

        await using var stream = file.OpenReadStream();
        await fileStorageService.PutObjectAsync(new PutObjectRequest
        {
            BucketName = S3Buckets.LocationsPhotos,
            Key = filename,
            ContentType = file.ContentType,
            InputStream = stream,
            CannedACL = S3CannedACL.PublicRead
        }, cancellationToken);

        return filename;
    }
}