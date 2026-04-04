using Amazon.S3.Model;
using Events.Application.Services.Features.Files;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetPlaceholders;

/// <inheritdoc />
public sealed class GetEventsPlaceholdersHandler(IFileStorageService storageService)
    : IRequestHandler<GetEventsPlaceholdersQuery, IReadOnlyCollection<string>>
{
    /// <inheritdoc />
    public async Task<IReadOnlyCollection<string>> Handle(GetEventsPlaceholdersQuery request,
        CancellationToken cancellationToken)
    {
        var listObjectsV2Request = new ListObjectsV2Request
        {
            BucketName = S3Buckets.EventsPlaceholders
        };

        var response = await storageService.ListObjectsAsync(listObjectsV2Request, cancellationToken);

        return response.S3Objects.Select(obj => obj.Key).ToList();
    }
}