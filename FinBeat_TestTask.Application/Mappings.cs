using FinBeat_TestTask.Application.DTO.Item;
using FinBeat_TestTask.Application.Requests;
using FinBeat_TestTask.Domain.Entities.Item;

namespace FinBeat_TestTask.Application
{
    public static class Mappings
    {
        public static ItemDTO AsDTO(this Item entity)
        {
            return new ItemDTO
            {
                Id = entity.Id,
                Code = entity.Code,
                Value = entity.Value
            };
        }

        public static IEnumerable<Item> AsEntity(this IEnumerable<SaveItemsRequest> items)
        {
            return items.Select(item => new Item
                {
                    Code = int.Parse(item.Code), //todo parse json
                    Value = item.Value
                });
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
