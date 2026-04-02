using Events.Contracts.Features.Users;
using MediatR;

namespace Events.Application.Services.Features.Users.Commands.ChangePassword;

public record ChangePasswordCommand(Guid UserId, ChangePasswordDto Dto) : IRequest;