using Events.Domain.Shared;

namespace Events.Domain.Aggregates.Users.Errors;

public static class UserErrors
{
    public static Error Unauthorized => new("User.Unauthorized", "Неверный почтовый адрес или пароль.");

    public static Error RoleAlreadyAssigned => new("User.RoleAlreadyAssigned", "Роль уже присвоена.");

    public static Error EmailAlreadyInUse => new("User.EmailAlreadyInUse", "Почтовый адрес уже используется.");

    public static Error NotFoundByFilter => new("User.NotFoundByFilter", "Пользователи по фильтру не найдены.");

    public static Error NotFoundById(Guid userId)
    {
        return new Error("User.NotFoundById", $"Пользователь с ID: {userId} не найден.");
    }

    public static Error ViewedEventsNotFoundById(Guid userId)
    {
        return new Error("User.ViewedEventsNotFoundById", $"Просмотры мероприятий пользователя с ID: {userId} не найдены.");
    }
}
