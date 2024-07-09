﻿using FinBeat_TestTask.Application.Requests;
using FinBeat_TestTask.Application.Response;
using FinBeat_TestTask.Application.Services.Interfaces;
using FinBeat_TestTask.Domain.Repositories;

namespace FinBeat_TestTask.Application.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<List<ItemResponse>> GetListAsync(GetItemsRequest filter, CancellationToken ct)
        {
            var data = await _itemRepository
                .GetListAsync(filter.AsEntity(), ct);

            return data.Select(x => x.AsDTO()).ToList();
        }

        public async Task SaveAsync(IEnumerable<SaveItemsRequest> items, CancellationToken ct)
        {
            var orderedData = items
                .AsEntity()
                .OrderBy(ob => ob.Code)
                .ToList();

            await _itemRepository.SaveAsync(orderedData, ct);
        }
        public async Task DeleteAllAsync(CancellationToken ct)
        {
            await _itemRepository.DeleteAllAsync(ct);
        }
    }
}
