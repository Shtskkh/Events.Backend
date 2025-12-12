using Events.Domain.Aggregates.EventAggregate;

namespace Events.Unit.Tests.Domain.Aggregates.Helpers;

public class EventTestBuilder
{
    private Guid _id = Guid.NewGuid();
    private string _title = "Test title";
    private string _announcement = "Test announcement";
    private string _description = "Test description";
    private int _maxParticipant = 0;
    private bool _isPublic = false;
    private bool _isNeedsRegistration = false;

    public EventTestBuilder WithId(Guid id)
    {
        _id = id;
        return this;
    }

    public EventTestBuilder WithTitle(string title)
    {
        _title = title;
        return this;
    }

    public EventTestBuilder WithAnnouncement(string announcement)
    {
        _announcement = announcement;
        return this;
    }

    public EventTestBuilder WithDescription(string description)
    {
        _description = description;
        return this;
    }

    public EventTestBuilder WithMaxParticipant(int maxParticipant)
    {
        _maxParticipant = maxParticipant;
        return this;
    }

    public EventTestBuilder WithIsPublic(bool isPublic)
    {
        _isPublic = isPublic;
        return this;
    }

    public EventTestBuilder WithIsNeedsRegistration(bool isNeedsRegistration)
    {
        _isNeedsRegistration = isNeedsRegistration;
        return this;
    }

    public Event Build()
    {
        return new Event(
            id: _id,
            title: _title,
            announcement: _announcement,
            description: _description,
            maxParticipant: _maxParticipant,
            isPublic: _isPublic,
            isNeedsRegistration: _isNeedsRegistration
        );
    }
}