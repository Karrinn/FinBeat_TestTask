using System.Net;

namespace FinBeat_TestTask.Application.Exceptions
{
    public class ExceptionResponse
    {
        public ExceptionResponse(int statusCode, string code, string? reason = null)
        {
            StatusCode = statusCode;
            Code = code;
            Reason = reason;
        }

        public int StatusCode { get; set; }
        public string Code { get; set; }
        public string? Reason { get; set; }

    }
}
