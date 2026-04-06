using Events.Contracts.Events;
using Events.Domain.Aggregates.EventAggregate.Errors;
using FluentValidation;

namespace Events.Application.Services.Features.Events.Commands.Create;

/// <inheritdoc />
public sealed class CreateEventValidator : AbstractValidator<CreateEventDto>
{
    /// <inheritdoc />
    public CreateEventValidator()
    {
        RuleFor(x => x)
            .Must(x => x.Preview == null || string.IsNullOrWhiteSpace(x.Placeholder))
            .WithMessage(EventErrorMessages.Preview.PlaceholderAndPreviewCannotBothBeSet)
            .DependentRules(() =>
            {
                RuleFor(x => x)
                    .Must(x => x.Preview != null || !string.IsNullOrWhiteSpace(x.Placeholder))
                    .WithMessage(EventErrorMessages.Preview.PlaceholderAndPreviewCannotBothBeEmpty);
            });

        RuleFor(x => x.Preview)
            .Must(x => x.Length <= CreateEventConstraints.MaxSize)
            .WithMessage(CreateEventErrorMessages.PreviewFileSizeExceedsLimit)
            .Must(x => CreateEventConstraints.AllowedMimeTypes.Contains(x.ContentType))
            .WithMessage(CreateEventErrorMessages.PreviewFileContentTypeNotAllowed)
            .When(x => x.Preview != null);
    }
}