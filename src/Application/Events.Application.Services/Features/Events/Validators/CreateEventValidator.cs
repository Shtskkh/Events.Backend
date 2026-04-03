using Events.Application.Services.Shared;
using Events.Contracts.Events;
using Events.Domain.Aggregates.EventAggregate.Errors;
using Events.Domain.Shared;
using FluentValidation;

namespace Events.Application.Services.Features.Events.Validators;

/// <inheritdoc />
public class CreateEventValidator : AbstractValidator<CreateEventDto>
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
            .Must(x => x.Length <= ApplicationConstraints.Event.Creation.MaxSize)
            .WithMessage(ApplicationErrorMessages.Event.Creation.PreviewFileSizeExceedsLimit)
            .Must(x => ApplicationConstraints.Event.Creation.AllowedMimeTypes.Contains(x.ContentType))
            .WithMessage(ApplicationErrorMessages.Event.Creation.PreviewFileContentTypeNotAllowed)
            .When(x => x.Preview != null);
    }
}