namespace Events.Domain.Shared;

public static class DomainConstraints
{
    public static class Event
    {
        public static class EventTitle
        {
            public const int MinLength = 5;

            public const int MaxLength = 128;
        }
    }
}