using FastEndpoints;
using FinBeat_TestTask.Application.Requests;
using FinBeat_TestTask.Application.Services.Interfaces.Item;

namespace FinBeat_TestTask.API.Endpoints
{
    public class GetItemsEndpoint : Endpoint<GetItemsRequest>
    {
        private readonly IItemService _itemService;

        public GetItemsEndpoint(IItemService itemService)
        {
            _itemService = itemService;
        }

        public override void Configure()
        {
            Get("/items");
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
