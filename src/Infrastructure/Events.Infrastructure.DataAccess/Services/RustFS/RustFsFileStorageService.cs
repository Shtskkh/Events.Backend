using System.Net;
using Amazon.S3;
using Amazon.S3.Model;
using Events.Application.Services.Features.Files;
using Events.Domain.Aggregates.Files.Errors;
using Events.Domain.Exceptions;

namespace Events.Infrastructure.DataAccess.Services.RustFS;

/// <summary>
///     RustFs сервис.
/// </summary>
public class RustFsFileStorageService(IAmazonS3 s3Client) : IFileStorageService
{
    /// <inheritdoc />
    public async Task PutObjectAsync(PutObjectRequest request, CancellationToken cancellationToken)
    {
        await s3Client.PutObjectAsync(request, cancellationToken);
    }

    /// <inheritdoc />
    public async Task DeleteObjectAsync(DeleteObjectRequest request, CancellationToken cancellationToken)
    {
        try
        {
            await s3Client.DeleteObjectAsync(request, cancellationToken);
        }
        catch (AmazonS3Exception e) when (e.StatusCode == HttpStatusCode.NotFound)
        {
            throw new NotFoundException(FileErrors.FileNotFoundByName(request.Key));
        }
    }

    public async Task<DeleteObjectsResponse> DeleteObjectsAsync(DeleteObjectsRequest request,
        CancellationToken cancellationToken)
    {
        return await s3Client.DeleteObjectsAsync(request, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<GetObjectResponse> GetObjectAsync(GetObjectRequest request, CancellationToken cancellationToken)
    {
        try
        {
            return await s3Client.GetObjectAsync(request, cancellationToken);
        }
        catch (AmazonS3Exception e) when (e.StatusCode == HttpStatusCode.NotFound)
        {
            throw new NotFoundException(FileErrors.FileNotFoundByName(request.Key));
        }
    }

    /// <inheritdoc />
    public async Task<ListObjectsV2Response> ListObjectsAsync(ListObjectsV2Request request,
        CancellationToken cancellationToken)
    {
        var objects = await s3Client.ListObjectsV2Async(request, cancellationToken);

        if (objects.S3Objects == null || objects.S3Objects.Count == 0)
            throw new NotFoundException(FileErrors.NotFoundAny);

        return objects;
    }
}