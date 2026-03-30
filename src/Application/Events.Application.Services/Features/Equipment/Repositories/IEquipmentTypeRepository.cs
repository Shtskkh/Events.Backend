using Events.Domain.Aggregates.EquipmentAggregate;

namespace Events.Application.Services.Features.Equipment.Repositories;

/// <summary>
///     Репозиторий типов оборудования.
/// </summary>
public interface IEquipmentTypeRepository
{
    /// <summary>
    ///     Получить все.
    /// </summary>
    /// <returns>Коллекция типов.</returns>
    Task<IReadOnlyCollection<EquipmentType>> GetAllAsync(CancellationToken cancellationToken);

    /// <summary>
    ///     Получить тип по ID.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Тип.</returns>
    Task<EquipmentType> GetByIdAsync(int id, CancellationToken cancellationToken);

    /// <summary>
    ///     Добавить тип.
    /// </summary>
    /// <param name="equipmentType">Объект типа.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>ID нового типа.</returns>
    Task AddAsync(EquipmentType equipmentType, CancellationToken cancellationToken);

    /// <summary>
    ///     Обновить тип.
    /// </summary>
    /// <param name="equipmentType">Объект типа.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    Task UpdateAsync(EquipmentType equipmentType, CancellationToken cancellationToken);

    /// <summary>
    ///     Удалить тип оборудования.
    /// </summary>
    /// <param name="equipmentType">Объект типа.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    Task DeleteAsync(EquipmentType equipmentType, CancellationToken cancellationToken);
}