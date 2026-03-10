using Events.Application.Services.Shared;
using Events.Contracts.Features.Events.DTOs;
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
            .WithMessage(DomainErrorMessages.Event.Preview.PlaceholderAndPreviewCannotBothBeSet)
            .DependentRules(() =>
            {
                RuleFor(x => x)
                    .Must(x => x.Preview != null || !string.IsNullOrWhiteSpace(x.Placeholder))
                    .WithMessage(DomainErrorMessages.Event.Preview.PlaceholderAndPreviewCannotBothBeEmpty);
            });

        RuleFor(x => x.Preview)
            .Must(x => x.Length <= 5 * 1024 * 1024)
            .When(x => x.Preview != null)
            .WithMessage(ApplicationErrorMessages.Event.Creation.PreviewFileSizeExceedsLimit);
    }
}