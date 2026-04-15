using Events.Contracts.Events;
using Events.Domain.Aggregates.Events.Errors;
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
            .WithMessage(EventPreviewErrors.PlaceholderAndPreviewCannotBothBeSet.ErrorMessage)
            .DependentRules(() =>
            {
                RuleFor(x => x)
                    .Must(x => x.Preview != null || !string.IsNullOrWhiteSpace(x.Placeholder))
                    .WithMessage(EventPreviewErrors.PlaceholderAndPreviewCannotBothBeEmpty.ErrorMessage);
            });

        RuleFor(x => x.Preview)
            .Must(x => x.Length <= CreateEventConstraints.MaxSize)
            .WithMessage(CreateEventErrorMessages.PreviewFileSizeExceedsLimit)
            .Must(x => CreateEventConstraints.AllowedMimeTypes.Contains(x.ContentType))
            .WithMessage(CreateEventErrorMessages.PreviewFileContentTypeNotAllowed)
            .When(x => x.Preview != null);
    }
}