using Events.Domain.Shared;

namespace Events.Domain.Aggregates.Events.Errors;

public class EventPreviewErrors
{
    public static Error PlaceholderAndPreviewCannotBothBeEmpty =>
        new("EventPreview.PlaceholderAndPreviewCannotBothBeEmpty", "Необходимо указать либо превью, либо плейсхолдер.");

    public static Error PlaceholderAndPreviewCannotBothBeSet =>
        new("EventPreview.PlaceholderAndPreviewCannotBothBeSet", "Нельзя указать одновременно превью и плейсхолдер.");
}