using FinBeat_TestTask.Application.Requests;
using FinBeat_TestTask.Application.Response;

namespace FinBeat_TestTask.Application.Services.Interfaces
{
    public interface IItemService
    {
        Task<List<ItemResponse>> GetListAsync(GetItemsRequest filter, CancellationToken ct);

        Task SaveAsync(IEnumerable<SaveItemsRequest> items, CancellationToken ct);

        Task DeleteAllAsync(CancellationToken ct);
    }
}
