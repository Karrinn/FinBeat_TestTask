using FinBeat_TestTask.Domain.Entities.Item;

namespace FinBeat_TestTask.Domain.Repositories.ItemRepository
{
    public interface IItemRepository
    {
        /// <summary>
        /// Получить данные, с возможностью применения фильтра
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<IEnumerable<Item>> GetListAsync(ItemFilter filter, CancellationToken ct);

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

        /// <summary>
        /// Удалить данные (физически)
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        Task MarkAllAsDeletedAsync(CancellationToken ct);
    }
}
