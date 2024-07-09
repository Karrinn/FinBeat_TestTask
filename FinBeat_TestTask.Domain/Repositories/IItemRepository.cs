using FinBeat_TestTask.Domain.Entities;

namespace FinBeat_TestTask.Domain.Repositories
{
    public interface IItemRepository
    {
        /// <summary>
        /// Получить данные, с возможностью применения фильтра
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<List<Item>> GetListAsync(ItemFilter filter, CancellationToken ct);

        /// <summary>
        /// Сохранить данные
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        Task SaveAsync(IEnumerable<Item> items, CancellationToken ct);

        /// <summary>
        /// Удалить данные (физически)
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        Task DeleteAllAsync(CancellationToken ct);

    }
}
