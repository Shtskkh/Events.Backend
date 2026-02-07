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
}