using Amazon.S3.Model;
using Events.Application.Services.Features.Files;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetAllEventsPlaceholders;

/// <inheritdoc />
public class GetAllEventsPlaceholdersHandler(IFileStorageService storageService)
    : IRequestHandler<GetAllEventsPlaceholdersQuery, IReadOnlyCollection<string>>
{
    /// <inheritdoc />
    public async Task<IReadOnlyCollection<string>> Handle(GetAllEventsPlaceholdersQuery request,
        CancellationToken cancellationToken)
    {
        var listObjectsV2Request = new ListObjectsV2Request
        {
            BucketName = S3Buckets.EventsPlaceholders
        };

        var response = await storageService.ListObjectsAsync(listObjectsV2Request);

        return response.S3Objects.Select(obj => obj.Key).ToList();
    }
}