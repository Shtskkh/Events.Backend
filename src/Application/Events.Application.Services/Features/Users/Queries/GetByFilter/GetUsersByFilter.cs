using Events.Contracts.Users;
using MediatR;

namespace Events.Application.Services.Features.Users.Queries.GetByFilter;

public sealed record GetUsersByFilter(UserFilterDto Filter) : IRequest<IReadOnlyCollection<ShortUserDto>>;