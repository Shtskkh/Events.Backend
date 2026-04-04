using Amazon.S3;
using Amazon.S3.Model;
using Events.Application.Services.Features.Events.Repositories;
using Events.Application.Services.Features.Files;
using Events.Application.Services.Features.Places.Repositories;
using Events.Domain.Aggregates.EventAggregate;
using Events.Domain.Aggregates.EventAggregate.Errors;
using Events.Domain.Aggregates.EventAggregate.Factories;
using Events.Domain.Exceptions;
using MediatR;

namespace Events.Application.Services.Features.Events.Commands.Create;

/// <inheritdoc />
public class CreateEventHandler(
    IEventRepository eventRepository,
    IEventTypeRepository eventTypeRepository,
    IEventFormatRepository eventFormatRepository,
    IPlaceRepository placeRepository,
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

            if (eventFormat.Id != EventFormat.Online.Id && dto.PlaceId.HasValue)
            {
                if (dto.PlaceId.HasValue)
                    await placeRepository.GetById(dto.PlaceId.Value, cancellationToken);

                var hasConflict = await eventRepository.HasBookingConflictAsync(
                    dto.PlaceId.Value, dto.StartDateTime, dto.EndDateTime, cancellationToken);

                if (hasConflict)
                    throw new DomainException(EventErrorMessages.Booking.TimeConflict);
            }

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
                dto.PlaceId,
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