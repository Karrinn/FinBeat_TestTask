using FinBeat_TestTask.Application.DTO.Item;
using FinBeat_TestTask.Application.Requests;
using FinBeat_TestTask.Application.Services.Interfaces.Item;
using FinBeat_TestTask.Domain.Repositories.ItemRepository;

namespace FinBeat_TestTask.Application.Services.Item
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository) 
        {
            _itemRepository = itemRepository;
        }

        public async Task<IEnumerable<ItemDTO>> GetListAsync(GetItemsRequest filter, CancellationToken ct)
        {
            var data = await _itemRepository
                .GetListAsync(filter.AsEntity(), ct);
         
            return data.Select(x => x.AsDTO());
        }

        public async Task SaveAsync(IEnumerable<SaveItemsRequest> items, CancellationToken ct)
        {
            var orderedData = items
                .AsEntity()
                .OrderBy(ob => ob.Code)
                .ToList();

            await _itemRepository.SaveAsync(orderedData, ct);
        }
    }
}
