using FinBeat_TestTask.Domain.Entities;

namespace FinBeat_TestTask.Domain.Repositories
{
    public interface IItemRepository
    {
        /// <summary>
        /// Получить данные, с возможностью применения фильтра
        /// </summary>
        /// <param name="filter">Класс для фильтрации результата</param>
        /// <returns>Список Item'ов</returns>
        Task<List<Item>> GetListAsync(ItemFilter? filter, CancellationToken ct);

        /// <summary>
        /// Сохранить данные
        /// </summary>
        /// <param name="items">Список Item'ов для сохранения в бд</param>
        Task SaveAsync(IEnumerable<Item> items, CancellationToken ct);

        /// <summary>
        /// Удалить все данные
        /// </summary>
        Task DeleteAllAsync(CancellationToken ct);

    }
}
