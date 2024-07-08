namespace FinBeat_TestTask.Application.Requests
{
    public class SaveItemsRequest
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string? Value { get; set; }
    }
}
