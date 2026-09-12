using Events.Contracts.Events;
using FluentValidation;

namespace Events.Application.Services.Features.Events.Queries.GetByFilter;

/// <summary>
///     Валидация для фильтра мероприятий.
/// </summary>
public sealed class EventFilterValidator : AbstractValidator<EventFilterDto>
{
    public EventFilterValidator()
    {
        RuleFor(filter => filter.TypeId)
            .GreaterThan(0).WithMessage(EventFilterErrorMessages.TypeIdLessOrEqualToZero)
            .When(filter => filter.TypeId.HasValue);

        RuleFor(filter => filter.FormatId)
            .GreaterThan(0).WithMessage(EventFilterErrorMessages.FormatIdLessOrEqualToZero)
            .When(filter => filter.TypeId.HasValue);

        RuleFor(filter => filter.Page)
            .GreaterThan(0).WithMessage(EventFilterErrorMessages.PageLessOrEqualToZero);

        RuleFor(filter => filter.Size)
            .GreaterThan(0).WithMessage(EventFilterErrorMessages.SizeLessOrEqualToZero)
            .LessThanOrEqualTo(EventFilterConstraints.MaxSize)
            .WithMessage(EventFilterErrorMessages.SizeGreaterThanMax);
    }
}