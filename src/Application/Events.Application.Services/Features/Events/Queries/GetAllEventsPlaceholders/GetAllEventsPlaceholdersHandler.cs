using Amazon.S3;
using Amazon.S3.Model;
using Events.Application.Services.Features.Files;
using Events.Contracts.Features.Events.DTOs;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetAllEventsPlaceholders;

public class GetAllEventsPlaceholdersHandler(IFileStorageService storageService)
    : IRequestHandler<GetAllEventsPlaceholdersQuery, IReadOnlyCollection<EventPlaceholderDto>>
{
    public async Task<IReadOnlyCollection<EventPlaceholderDto>> Handle(GetAllEventsPlaceholdersQuery request,
        CancellationToken cancellationToken)
    {
        var listObjectsV2Request = new ListObjectsV2Request
        {
            BucketName = S3Buckets.EventsPlaceholders
        };

        var response = await storageService.ListObjectsAsync(listObjectsV2Request);

        var dtos = new List<EventPlaceholderDto>();

        var dtosTasks = response.S3Objects.Select(async o =>
        {
            var downloadRequest = new GetPreSignedUrlRequest
            {
                BucketName = S3Buckets.EventsPlaceholders,
                Key = o.Key,
                Expires = DateTime.Now.AddMinutes(5),
                Protocol = Protocol.HTTP
            };

            var downloadLink = await storageService.GeneratePresignedUrlAsync(downloadRequest);

            var dto = new EventPlaceholderDto
            {
                Filename = o.Key,
                DownloadLink = new Uri(downloadLink)
            };

            dtos.Add(dto);
        });

        await Task.WhenAll(dtosTasks);

        return dtos;
    }
}