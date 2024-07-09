using FastEndpoints;
using FinBeat_TestTask.Application.Requests;
using FinBeat_TestTask.Application.Services.Interfaces;

namespace FinBeat_TestTask.API.Endpoints
{
    public class SaveItemsEndpoint : Endpoint<IEnumerable<Dictionary<string, string>>>
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

        public override async Task HandleAsync(IEnumerable<Dictionary<string, string>> jsonData, CancellationToken ct)
        {
            var data = jsonData.Select(item =>
                new SaveItemsRequest
                {
                    Code = item.Keys.First(),
                    Value = item.Values.First()
                })
                .ToList();

            await _itemService.DeleteAllAsync(ct);
            await _itemService.SaveAsync(data, ct);

            await SendOkAsync(ct);
        }

    }
}
