namespace Events.Domain.Shared;

public static class DomainConstraints
{
    public static class Event
    {
        public static class Title
        {
            public const int MinLength = 5;

            public const int MaxLength = 128;
        }

        public static class Announcement
        {
            public const int MinLength = 5;

            public const int MaxLength = 64;
        }

        public static class Description
        {
            public const int MinLength = 5;

            public const int MaxLength = 512;
        }
    }
}