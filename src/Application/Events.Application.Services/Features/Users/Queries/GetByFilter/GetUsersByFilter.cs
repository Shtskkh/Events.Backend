using Events.Contracts.Users;
using MediatR;

namespace Events.Application.Services.Features.Users.Queries.GetByFilter;

/// <inheritdoc />
public sealed record GetUsersByFilter(UserFilterDto Filter) : IRequest<IReadOnlyCollection<ShortUserDto>>;