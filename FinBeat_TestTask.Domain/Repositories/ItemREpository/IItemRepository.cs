using FinBeat_TestTask.Domain.Entities.Item;

namespace FinBeat_TestTask.Domain.Repositories.ItemREpository
{
    public interface IItemRepository
    {
        /// <summary>
        /// Получить данные, с возможностью применения фильтра
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<IList<Item>> GetListAsync(ItemFilter filter);

        /// <summary>
        /// Сохранить данные
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        Task SaveAsync(IEnumerable<Item> items);
    }
}
