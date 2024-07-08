using FastEndpoints;
using FinBeat_TestTask.Application.Requests;
using FinBeat_TestTask.Application.Services.Interfaces.Item;

namespace FinBeat_TestTask.API.Endpoints
{
    public class SaveItemsEndpoint : Endpoint<IEnumerable<SaveItemsRequest>>
    {
        private readonly IItemService _itemService;

        public SaveItemsEndpoint(IItemService itemService)
        {
            _itemService = itemService;
        }

        public override void Configure()
        {
            Post("/items");
            AllowAnonymous();
        }

        public override async Task HandleAsync(IEnumerable<SaveItemsRequest> data, CancellationToken ct)
        {
            //json parse
            await _itemService.SaveAsync(data, ct);
            await SendOkAsync(ct);
        }

    }
}
