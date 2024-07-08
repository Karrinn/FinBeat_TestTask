using FastEndpoints;
using FinBeat_TestTask.Application.Requests;
using FinBeat_TestTask.Application.Services.Item;

namespace FinBeat_TestTask.API.Endpoints
{
    public class GetItemsEndpoint : Endpoint<GetItemsRequest>
    {
        private readonly ItemService _itemService;

        public GetItemsEndpoint(ItemService itemService)
        {
            _itemService = itemService;
        }

        public override void Configure()
        {
            Post("/items");
            AllowAnonymous();
        }

        public override async Task HandleAsync(GetItemsRequest filter, CancellationToken ct)
        {
            var items = await _itemService.GetListAsync(filter, ct);
            if (items is null)
            {
                await SendNotFoundAsync(ct);
                return;
            }

            await SendOkAsync(items, ct);
        }

    }
}
