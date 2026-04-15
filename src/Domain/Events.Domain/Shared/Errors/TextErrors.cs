using Events.Domain.Shared;

namespace Events.Domain.Shared.Errors;

public static class TextErrors
{
    public static Error NullOrWhiteSpace => new("Text.NullOrWhiteSpace", "Текстовое поле не может быть null или пустым.");
}
