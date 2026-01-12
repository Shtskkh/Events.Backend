namespace Events.Domain.Shared;

public static class DomainErrorMessages
{
    public static class Text
    {
        public const string NullOrWhiteSpace = "Текстовое поле не может быть null или пустым.";
    }

    public static class Event
    {
        public static class Title
        {
            public const string LessThanMinLenght = "Название мероприятия меньше минимальной длины.";

            public const string GreaterThanMaxLength = "Название мероприятия больше максимальной длины.";
        }
    }
}