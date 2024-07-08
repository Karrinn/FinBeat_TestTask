using FinBeat_TestTask.Application.DTO.Item;
using FinBeat_TestTask.Application.Requests;

namespace FinBeat_TestTask.Application.Services.Interfaces.Item
{
    public interface IItemService
    {
        Task<IEnumerable<ItemDTO>> GetListAsync(GetItemsRequest filter, CancellationToken ct);

        Task SaveAsync(IEnumerable<SaveItemsRequest> items, CancellationToken ct);

        Task DeleteAllAsync(CancellationToken ct);
    }
}
