using System.Text.Json.Serialization;

namespace FinBeat_TestTask.Application.Requests
{
    public class SaveItemsRequest
    {
        public string Code { get; set; }
        public string Value { get; set; }
    }
}
