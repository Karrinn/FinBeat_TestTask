using FinBeat_TestTask.Application.Response;
using FinBeat_TestTask.Application.Requests;
using FinBeat_TestTask.Domain.Entities;

namespace FinBeat_TestTask.Application
{
    public static class Mappings
    {
        public static ItemResponse AsDTO(this Item entity)
        {
            return new ItemResponse
            {
                Id = entity.Id,
                Code = entity.Code,
                Value = entity.Value
            };
        }

        public static List<Item> AsEntity(this IEnumerable<SaveItemsRequest> items)
        {
            return items.Select(item => new Item
                {
                    Code = int.Parse(item?.Code ?? "0"),
                    Value = item?.Value
                })
                .ToList();
        }

        public static ItemFilter AsEntity(this GetItemsRequest item)
        {
            return new ItemFilter
            {
                Code = item.Code,
                Value = item.Value
            };
        }
    }
}
