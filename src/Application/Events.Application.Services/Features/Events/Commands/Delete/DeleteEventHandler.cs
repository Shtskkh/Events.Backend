using Amazon.S3.Model;
using Events.Application.Services.Features.Events.Repositories;
using Events.Application.Services.Features.Files;
using MediatR;

namespace Events.Application.Services.Features.Events.Commands.Delete;

/// <inheritdoc />
public sealed class DeleteEventHandler(IEventRepository eventRepository, IFileStorageService storageService)
    : IRequestHandler<DeleteEventQuery>
{
    /// <inheritdoc />
    public async Task Handle(DeleteEventQuery request, CancellationToken cancellationToken)
    {
        var @event = await eventRepository.GetByIdAsync(request.EventId, cancellationToken);
        var previewFilename = @event.PreviewFilename;

        await eventRepository.DeleteAsync(@event, cancellationToken);

        if (previewFilename != null)
        {
            var deleteObjectRequest = new DeleteObjectRequest
            {
                BucketName = S3Buckets.EventsPreviews,
                Key = previewFilename
            };

            await storageService.DeleteObjectAsync(deleteObjectRequest, cancellationToken);
        }
    }
}