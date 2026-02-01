using Events.Application.Services.Shared;
using Events.Contracts.Features.Events.DTOs;
using FluentValidation;

namespace Events.Application.Services.Features.Events.Validators;

/// <summary>
///     Валидация для фильтра мероприятий.
/// </summary>
public class EventFilterValidator : AbstractValidator<EventFilterDto>
{
    /// <summary>
    ///     Конструктор валидатора фильтра мероприятий.
    /// </summary>
    public EventFilterValidator()
    {
        RuleFor(filter => filter.Page)
            .GreaterThan(0).WithMessage(ApplicationErrorMessages.Event.Filter.PageLessOrEqualToZero);

        RuleFor(filter => filter.Size)
            .GreaterThan(0).WithMessage(ApplicationErrorMessages.Event.Filter.SizeLessOrEqualToZero)
            .LessThanOrEqualTo(ApplicationConstraints.Event.Filter.MaxSize)
            .WithMessage(ApplicationErrorMessages.Event.Filter.SizeGreaterThanMax);
    }
}