using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Unit.Tests.Domain.Aggregates.EventAggregate.Helpers;
using FluentAssertions;

namespace Events.Unit.Tests.Domain.Aggregates.EventAggregate.ValueObjects;

public class EventMaxParticipantsTests
{
    [Theory]
    [InlineData(0)]
    [InlineData(DomainConstraints.Event.MinParticipantsCount)]
    public void Constructor_WithValidMaxParticipants_ShouldSetCorrectly(int maxParticipants)
    {
        // Act
        var @event = new EventTestBuilder()
            .WithMaxParticipants(maxParticipants)
            .Build();

        // Assert
        @event.MaxParticipants.Value.Should().Be(maxParticipants);
    }

    [Fact]
    public void Constructor_WithInvalidMaxParticipants_ShouldThrow()
    {
        // Act
        var act = () => new EventTestBuilder()
            .WithMaxParticipants(DomainConstraints.Event.MinParticipantsCount - 1)
            .Build();

        // Assert
        act.Should()
            .Throw<DomainException>()
            .WithMessage(DomainErrorMessages.EventErrors.MaxParticipantsCountLessThanMin);
    }
}