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
            var result = await _itemRepository.GetListAsync(filter.AsEntity(), ct);

            return result
                .Select(i => i.AsDTO())
                .ToList();
        }

        public async Task SaveAsync(IEnumerable<SaveItemsRequest> items, CancellationToken ct)
        {
            await _itemRepository.SaveAsync(items.AsEntity(), ct);
        }
    }
}
