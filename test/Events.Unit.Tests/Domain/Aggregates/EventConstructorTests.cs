using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Unit.Tests.Domain.Aggregates.Helpers;
using FluentAssertions;

namespace Events.Unit.Tests.Domain.Aggregates;

public class EventConstructorTests
{
    [Fact]
    public void Constructor_ShouldSetMaxParticipantsToZero_ByDefault()
    {
        // Act
        var @event = new EventTestBuilder().Build();

        // Assert
        @event.MaxParticipants.Should().Be(DomainConstraints.Event.MinParticipantsCount);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(DomainConstraints.Event.MinParticipantsCount)]
    public void Constructor_WithValidMaxParticipants_ShouldSetCorrectly(int maxParticipants)
    {
        // Act
        var @event = new EventTestBuilder()
            .WithMaxParticipant(maxParticipants)
            .Build();

        // Assert
        @event.MaxParticipants.Should().Be(maxParticipants);
    }

    [Theory]
    [InlineData(DomainConstraints.Event.MinParticipantsCount - 1)]
    public void Constructor_WithInvalidMaxParticipants_ShouldThrow(int maxParticipants)
    {
        // Act
        var act = () => new EventTestBuilder()
            .WithMaxParticipant(maxParticipants)
            .Build();

        // Assert
        act.Should()
            .Throw<DomainException>()
            .WithMessage(DomainErrorMessages.EventErrors.MaxParticipantsCountLessThanMin);
    }
}