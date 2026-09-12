using Amazon.S3;
using Amazon.S3.Model;
using Events.Application.Services.Features.Files;
using Events.Application.Services.Shared;
using Events.Domain.Aggregates.Locations;
using Events.Domain.Aggregates.Locations.Factories.Locations;
using MediatR;

namespace Events.Application.Services.Features.Locations.Commands.Create;

public sealed class CreateLocationHandler(
    IRepository<Location> locationRepository,
    IFileStorageService fileStorageService)
    : IRequestHandler<CreateLocationCommand, int>
{
    public async Task<int> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;

        var location = LocationFactory.Create(dto.Title, dto.Address);

        List<string>? uploadedFilenames = null;
        try
        {
            if (dto.Photos is { Count: > 0 })
            {
                uploadedFilenames = [];

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
            }

            await locationRepository.AddAsync(location, cancellationToken);
        }
        catch (Exception)
        {
            if (uploadedFilenames != null)
                await fileStorageService.SafeDeleteObjectsAsync(
                    S3Buckets.LocationsPhotos,
                    uploadedFilenames,
                    cancellationToken);
            throw;
        }

        return location.Id;
    }
}