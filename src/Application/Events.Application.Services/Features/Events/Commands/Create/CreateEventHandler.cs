using Amazon.S3;
using Amazon.S3.Model;
using Events.Application.Services.Features.Events.Repositories;
using Events.Application.Services.Features.Files;
using Events.Application.Services.Features.Locations.Repositories;
using Events.Application.Services.Features.Locations.Specifications;
using Events.Domain.Aggregates.EventAggregate;
using Events.Domain.Aggregates.EventAggregate.Errors;
using Events.Domain.Aggregates.EventAggregate.Factories;
using Events.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Events.Application.Services.Features.Events.Commands.Create;

/// <inheritdoc />
public sealed class CreateEventHandler(
    IEventRepository eventRepository,
    IEventTypeRepository eventTypeRepository,
    IEventFormatRepository eventFormatRepository,
    ILocationRepository locationRepository,
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
            previewFilename = await UploadPreviewAsync(dto.Preview, cancellationToken);

            var eventType = await eventTypeRepository.GetById(dto.EventTypeId, cancellationToken);
            var eventFormat = await eventFormatRepository.GetByIdAsync(dto.EventFormatId, cancellationToken);

            if (eventFormat.Id != EventFormat.Online.Id)
                await ValidateBookingAsync(
                    dto.LocationId,
                    dto.PlaceId,
                    dto.StartDateTime,
                    dto.EndDateTime,
                    cancellationToken);

            var @event = EventFactory.Create(
                dto.Title,
                dto.Announcement,
                dto.Description,
                ToUtc(dto.StartDateTime),
                ToUtc(dto.EndDateTime),
                eventType,
                eventFormat,
                dto.UserId,
                dto.NeedsRegistration,
                dto.LocationId,
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
            await DeletePreviewIfUploadedAsync(previewFilename, cancellationToken);
            throw;
        }
    }

    private async Task<Guid?> UploadPreviewAsync(IFormFile? preview, CancellationToken cancellationToken)
    {
        if (preview == null)
            return null;

        var filename = Guid.NewGuid();
        var putRequest = new PutObjectRequest
        {
            BucketName = S3Buckets.EventsPreviews,
            Key = filename.ToString(),
            ContentType = preview.ContentType,
            InputStream = preview.OpenReadStream(),
            CannedACL = S3CannedACL.PublicRead
        };

        await fileStorageService.PutObjectAsync(putRequest, cancellationToken);

        return filename;
    }

    private async Task DeletePreviewIfUploadedAsync(Guid? previewFilename, CancellationToken cancellationToken)
    {
        if (!previewFilename.HasValue)
            return;

        await fileStorageService.SafeDeleteObjectsAsync(
            S3Buckets.EventsPreviews,
            [previewFilename.Value.ToString()],
            cancellationToken);
    }

    private async Task ValidateBookingAsync(
        int? locationId,
        int? placeId,
        DateTimeOffset start,
        DateTimeOffset end,
        CancellationToken cancellationToken)
    {
        if (!locationId.HasValue || !placeId.HasValue)
            throw new DomainException(EventErrorMessages.Booking.RequiredForOfflineAndHybrid);

        var spec = new LocationSpec().WithId(locationId.Value).IncludePlaces().AsNoTracking();
        var location = await locationRepository.GetAsync(spec, cancellationToken);

        location.FindPlace(placeId.Value);

        var hasConflict = await eventRepository.HasBookingConflictAsync(
            placeId.Value, ToUtc(start), ToUtc(end), cancellationToken);

        if (hasConflict)
            throw new DomainException(EventErrorMessages.Booking.TimeConflict);
    }

    private static DateTimeOffset ToUtc(DateTimeOffset dateTime)
    {
        return dateTime.Offset == TimeSpan.Zero ? dateTime : dateTime.ToUniversalTime();
    }
}