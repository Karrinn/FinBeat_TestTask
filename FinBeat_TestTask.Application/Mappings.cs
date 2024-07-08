using FinBeat_TestTask.Application.DTO.Item;
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

        public static ItemFilterDTO AsFilterDTO(this ItemFilter entity) 
        {
            return new ItemFilterDTO
            {
                Code = entity.Code,
                Value = entity.Value
            };
        }
    }
}
