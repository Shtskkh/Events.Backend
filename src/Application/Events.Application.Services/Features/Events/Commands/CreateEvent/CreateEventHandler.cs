using Amazon.S3;
using Amazon.S3.Model;
using Events.Application.Services.Features.Events.Repositories;
using Events.Application.Services.Features.Files;
using Events.Domain.Aggregates.EventAggregate.Factories;
using MediatR;

namespace Events.Application.Services.Features.Events.Commands.CreateEvent;

/// <inheritdoc />
public class CreateEventHandler(
    IEventRepository eventRepository,
    IEventTypeRepository eventTypeRepository,
    IEventFormatRepository eventFormatRepository,
    IFileStorageService fileStorageService)
    : IRequestHandler<CreateEventCommand, Guid>
{
    /// <inheritdoc />
    public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        Guid? previewFilename = null;
        var dto = request.Dto;

        try
        {
            if (dto.Preview != null)
            {
                previewFilename = Guid.NewGuid();
                var putRequest = new PutObjectRequest
                {
                    BucketName = S3Buckets.EventsPreviews,
                    Key = previewFilename.ToString(),
                    ContentType = dto.Preview.ContentType,
                    InputStream = dto.Preview.OpenReadStream(),
                    CannedACL = S3CannedACL.PublicRead
                };

                await fileStorageService.PutObjectAsync(putRequest, cancellationToken);
            }

            var eventType = await eventTypeRepository.GetById(dto.EventTypeId, cancellationToken);
            var eventFormat = await eventFormatRepository.GetByIdAsync(dto.EventFormatId, cancellationToken);

            var @event = EventFactory.Create(
                dto.Title,
                dto.Announcement,
                dto.Description,
                dto.StartDateTime,
                dto.EndDateTime,
                eventType,
                eventFormat,
                dto.UserId,
                dto.NeedsRegistration,
                dto.MaxParticipants,
                previewFilename?.ToString(),
                dto.Placeholder
            );

            await eventRepository.AddAsync(@event, cancellationToken);

            return @event.Id;
        }
        catch
        {
            if (previewFilename.HasValue)
            {
                var deleteRequest = new DeleteObjectRequest
                {
                    BucketName = S3Buckets.EventsPreviews,
                    Key = previewFilename.ToString()
                };

                await fileStorageService.DeleteObjectAsync(deleteRequest, cancellationToken);
            }

            throw;
        }
    }
}