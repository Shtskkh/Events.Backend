using Events.Domain.Aggregates.EventAggregate;
using Events.Domain.Shared;

namespace Events.Unit.Tests.Domain.Aggregates.EventAggregate.Helpers;

public class EventTestBuilder
{
    private Guid _id = Guid.NewGuid();
    private string _title = "Test title";
    private string _announcement = "Test announcement";
    private string _description = "Test description";
    private int _maxParticipants = DomainConstraints.Event.MinParticipantsCount;
    private bool _isPublic = true;
    private bool _needsRegistration = true;

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

    public EventTestBuilder WithMaxParticipants(int maxParticipants)
    {
        _maxParticipants = maxParticipants;
        return this;
    }

    public EventTestBuilder WithIsPublic(bool isPublic)
    {
        _isPublic = isPublic;
        return this;
    }

    public EventTestBuilder WithNeedsRegistration(bool needsRegistration)
    {
        _needsRegistration = needsRegistration;
        return this;
    }

    public Event Build()
    {
        return new Event(
            id: _id,
            title: _title,
            announcement: _announcement,
            description: _description,
            maxParticipants: _maxParticipants,
            isPublic: _isPublic,
            isNeedsRegistration: _needsRegistration,
            organizerId: Guid.NewGuid()
        );
    }
}