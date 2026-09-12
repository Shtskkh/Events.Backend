namespace Events.Application.Services.Interfaces;

public interface ICurrentUserProvider
{
    bool IsAuthenticated { get; }
    Guid? UserId { get; }
    string? Role { get; }
}