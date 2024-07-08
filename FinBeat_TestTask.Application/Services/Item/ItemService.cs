using FinBeat_TestTask.Application.DTO.Item;
using FinBeat_TestTask.Application.Services.Interfaces.Item;

namespace FinBeat_TestTask.Application.Services.Item
{
    public class ItemService : IItemService
    {
        public Task<IList<ItemDTO>> GetListAsync(ItemFilterDTO filter)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(IEnumerable<ItemDTO> items)
        {
            throw new NotImplementedException();
        }
    }
}
