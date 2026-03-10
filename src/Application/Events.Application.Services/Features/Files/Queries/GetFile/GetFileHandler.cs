using Amazon.S3.Model;
using Events.Contracts.Features.Files;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Events.Application.Services.Features.Files.Queries.GetFile;

/// <inheritdoc />
public class GetFileHandler(IFileStorageService storageService, ILogger<GetFileHandler> logger)
    : IRequestHandler<GetFileQuery, FileDto>
{
    /// <inheritdoc />
    public async Task<FileDto> Handle(GetFileQuery request, CancellationToken cancellationToken)
    {
        var getObjectRequest = new GetObjectRequest
        {
            BucketName = request.Bucket,
            Key = request.Key
        };

        var response = await storageService.GetObjectAsync(getObjectRequest, cancellationToken);

        var stream = response.ResponseStream;
        var contentType = response.Headers.ContentType;
        var contentLength = response.Headers.ContentLength;

        var fileDto = new FileDto
        {
            Content = stream,
            ContentType = contentType,
            Filename = request.Key,
            Length = contentLength
        };

        return fileDto;
    }
}