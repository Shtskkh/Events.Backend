using Events.Contracts.Features.Users;
using MediatR;

namespace Events.Application.Services.Features.Users.Queries.GetByFilter;

/// <inheritdoc />
public record GetUsersByFilter(UserFilterDto Filter) : IRequest<IReadOnlyCollection<ShortUserDto>>;