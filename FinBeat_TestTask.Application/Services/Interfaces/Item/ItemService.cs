using FinBeat_TestTask.Application.DTO.Item;

namespace FinBeat_TestTask.Application.Services.Interfaces.Item
{
    public interface IItemService
    {
        Task<IList<ItemDTO>> GetListAsync(ItemFilterDTO filter);

        Task SaveAsync(IEnumerable<ItemDTO> items);
    }
}
