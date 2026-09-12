using Events.Domain.Shared;

namespace Events.Domain.Aggregates.Users.Errors;

public static class UserRoleErrors
{
    public static Error GreaterThanMaxLength => new("UserRole.GreaterThanMaxLength",
        $"Название роли пользователя больше максимальной длины в {UserRole.MaxTitleLength} символ(-ов).");

    public static Error NotFoundById(int roleId)
    {
        return new Error("UserRole.NotFoundById", $"Роль с ID: {roleId} не найдена.");
    }
}