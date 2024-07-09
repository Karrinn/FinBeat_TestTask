namespace FinBeat_TestTask.Domain.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string? Value { get; set; }
        public bool IsDeleted { get; set; }
    }
}