using Events.Domain.Aggregates.UserAggregate;

namespace Events.Application.Services.Features.Users.Repositories;

/// <summary>
///     Репозиторий ролей пользователей.
/// </summary>
public interface IUserRoleRepository
{
    /// <summary>
    ///     Получить роль по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <returns>Объект роли пользователя.</returns>
    Task<UserRole> GetById(int id);
}