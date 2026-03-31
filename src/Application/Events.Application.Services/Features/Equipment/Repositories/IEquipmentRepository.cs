using Ardalis.Specification;

namespace Events.Application.Services.Features.Equipment.Repositories;

/// <summary>
///     Репозиторий оборудования.
/// </summary>
public interface IEquipmentRepository
{
    /// <summary>
    ///     Получить оборудование по фильтру.
    /// </summary>
    /// <param name="spec">Спецификация.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекция оборудования.</returns>
    Task<IReadOnlyCollection<Domain.Aggregates.EquipmentAggregate.Equipment>> GetByFilterAsync(
        Specification<Domain.Aggregates.EquipmentAggregate.Equipment> spec, CancellationToken cancellationToken);

    /// <summary>
    ///     Получить оборудование.
    /// </summary>
    /// <param name="spec">Спецификация.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Оборудование.</returns>
    Task<Domain.Aggregates.EquipmentAggregate.Equipment> GetAsync(
        Specification<Domain.Aggregates.EquipmentAggregate.Equipment> spec, CancellationToken cancellationToken);

    /// <summary>
    ///     Добавить оборудование.
    /// </summary>
    /// <param name="equipment">Оборудование.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    Task AddAsync(Domain.Aggregates.EquipmentAggregate.Equipment equipment, CancellationToken cancellationToken);

    /// <summary>
    ///     Обновить оборудование.
    /// </summary>
    /// <param name="equipment">Оборудование.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    Task UpdateAsync(Domain.Aggregates.EquipmentAggregate.Equipment equipment, CancellationToken cancellationToken);

    /// <summary>
    ///     Удалить оборудование.
    /// </summary>
    /// <param name="equipment">Оборудование.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    Task DeleteAsync(Domain.Aggregates.EquipmentAggregate.Equipment equipment, CancellationToken cancellationToken);
}