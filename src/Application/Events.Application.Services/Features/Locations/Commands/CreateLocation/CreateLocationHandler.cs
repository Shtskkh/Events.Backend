using Amazon.S3;
using Amazon.S3.Model;
using Events.Application.Services.Features.Files;
using Events.Application.Services.Features.Locations.Repositories;
using Events.Domain.Aggregates.LocationAggregate.Factories.Locations;
using MediatR;

namespace Events.Application.Services.Features.Locations.Commands.CreateLocation;

/// <inheritdoc />
public class CreateLocationHandler(ILocationRepository locationRepository, IFileStorageService fileStorageService)
    : IRequestHandler<CreateLocationCommand, int>
{
    /// <inheritdoc />
    public async Task<int> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;

        var location = LocationFactory.Create(dto.Title, dto.Address);

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
                        BucketName = S3Buckets.LocationsPhotos,
                        Key = filename,
                        ContentType = photo.ContentType,
                        InputStream = stream,
                        CannedACL = S3CannedACL.PublicRead
                    };

                    await fileStorageService.PutObjectAsync(putObjectRequest, cancellationToken);

                    uploadedFilenames.Add(filename);
                    location.AddPhoto(filename);
                }

            await locationRepository.AddAsync(location, cancellationToken);
        }
        catch (Exception)
        {
            await fileStorageService.SafeDeleteObjectsAsync(S3Buckets.LocationsPhotos, uploadedFilenames,
                cancellationToken);
            throw;
        }

        return location.Id;
    }
}