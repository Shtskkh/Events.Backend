namespace Events.Application.Services.Features.Events.Queries.GetByFilter;

/// <summary>
///     Ошибки фильтра мероприятий.
/// </summary>
public static class EventFilterErrorMessages
{
    public const string PageLessOrEqualToZero = "Страница выборки должна быть больше 0.";
    public const string SizeLessOrEqualToZero = "Размер выборки должен быть больше 0.";
    public const string TypeIdLessOrEqualToZero = "ID типа мероприятия должен быть больше 0.";
    public const string FormatIdLessOrEqualToZero = "ID формата мероприятия должен быть больше 0.";

    public static readonly string SizeGreaterThanMax =
        $"Размер выборки должен быть меньше чем {EventFilterConstraints.MaxSize}.";
}