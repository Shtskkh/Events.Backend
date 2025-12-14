using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Unit.Tests.Domain.Aggregates.EventAggregate.Helpers;
using FluentAssertions;

namespace Events.Unit.Tests.Domain.Aggregates.EventAggregate;

public class EventMaxParticipantsBehaviorTests
{
    [Theory]
    [InlineData(0)]
    [InlineData(DomainConstraints.Event.MinParticipantsCount)]
    [InlineData(DomainConstraints.Event.MinParticipantsCount + 1)]
    public void ChangeMaxParticipants_WithValidValue_ShouldChangeCorrectly(int newMaxParticipants)
    {
        // Arrange
        var @event = new EventTestBuilder().Build();

        // Act
        @event.ChangeMaxParticipants(newMaxParticipants);

        // Assert
        @event.MaxParticipants.Value.Should().Be(newMaxParticipants);
    }

    [Theory]
    [InlineData(DomainConstraints.Event.MinParticipantsCount - 1)]
    public void ChangeMaxParticipants_WithInvalidValue_ShouldThrowDomainException(int newMaxParticipants)
    {
        // Arrange
        var @event = new EventTestBuilder().Build();

        // Act
        var act = () => @event.ChangeMaxParticipants(newMaxParticipants);

        act.Should()
            .Throw<DomainException>()
            .WithMessage(DomainErrorMessages.EventErrors.MaxParticipantsCountLessThanMin);
    }
}