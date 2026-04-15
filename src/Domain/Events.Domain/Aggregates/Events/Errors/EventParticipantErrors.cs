using Events.Domain.Shared;

namespace Events.Domain.Aggregates.Events.Errors;

public static class EventParticipantErrors
{
    public static Error NotFoundAny => new("EventParticipant.NotFoundAny", "Участники мероприятия не найдены.");

    public static Error RegistrationNotRequired =>
        new("EventParticipant.RegistrationNotRequired", "Мероприятие не требует регистрации.");

    public static Error MaxCountMustBeSet => new("EventParticipant.MaxCountMustBeSet",
        "Для мероприятия с регистрацией необходимо указать максимальное количество участников.");

    public static Error MaxCountReached(int max)
    {
        return new Error("EventParticipant.MaxCountReached",
            $"Достигнуто максимальное количество участников мероприятия в {max} человек.");
    }

    public static Error AlreadyRegistered(Guid participantId)
    {
        return new Error("EventParticipant.AlreadyRegistered",
            $"Пользователь c ID: {participantId} уже зарегистрирован на мероприятие.");
    }

    public static Error NotFoundById(Guid participantId)
    {
        return new Error("EventParticipant.NotFound",
            $"Пользователь с ID: {participantId} не является участником мероприятия.");
    }
}