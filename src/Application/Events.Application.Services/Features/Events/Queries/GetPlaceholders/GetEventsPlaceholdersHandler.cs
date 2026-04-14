using Amazon.S3.Model;
using Events.Application.Services.Features.Files;
using Events.Domain.Aggregates.Events.Errors;
using Events.Domain.Exceptions;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetPlaceholders;

public sealed class GetEventsPlaceholdersHandler(IFileStorageService storageService)
    : IRequestHandler<GetEventsPlaceholdersQuery, IReadOnlyCollection<string>>
{
    public async Task<IReadOnlyCollection<string>> Handle(GetEventsPlaceholdersQuery request,
        CancellationToken cancellationToken)
    {
        var listObjectsV2Request = new ListObjectsV2Request
        {
            BucketName = S3Buckets.EventsPlaceholders
        };

        var response = await storageService.ListObjectsAsync(listObjectsV2Request, cancellationToken);

        var placeholders = response.S3Objects.Select(obj => obj.Key).ToList();

        if (placeholders.Count == 0)
            throw new NotFoundException(EventErrorMessages.Placeholders.NotFoundAny);

        return response.S3Objects.Select(obj => obj.Key).ToList();
    }
}