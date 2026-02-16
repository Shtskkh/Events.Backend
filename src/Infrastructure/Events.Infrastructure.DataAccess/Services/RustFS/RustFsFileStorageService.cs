using Amazon.S3;
using Amazon.S3.Model;
using Events.Application.Services.Features.Files;

namespace Events.Infrastructure.DataAccess.Services.RustFS;

/// <summary>
///     RustFs сервис.
/// </summary>
public class RustFsFileStorageService(IAmazonS3 s3Client) : IFileStorageService
{
    /// <inheritdoc />
    public async Task PutObjectAsync(PutObjectRequest request)
    {
        await s3Client.PutObjectAsync(request);
    }

    /// <inheritdoc />
    public async Task DeleteObjectAsync(DeleteObjectRequest request)
    {
        await s3Client.DeleteObjectAsync(request);
    }

    /// <inheritdoc />
    public async Task<string> GeneratePresignedUrlAsync(GetPreSignedUrlRequest request)
    {
        return await s3Client.GetPreSignedURLAsync(request);
    }

    /// <inheritdoc />
    public async Task<ListObjectsV2Response> ListObjectsAsync(ListObjectsV2Request request)
    {
        return await s3Client.ListObjectsV2Async(request);
    }
}