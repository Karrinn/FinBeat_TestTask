using System.Net;

namespace FinBeat_TestTask.Application.Exceptions
{
    public class ExceptionResponse
    {
        public ExceptionResponse(HttpStatusCode statusCode, string code, string? reason = null)
        {
            StatusCode = statusCode;
            Code = code;
            Reason = reason;
        }

        public HttpStatusCode StatusCode { get; set; }
        public string Code { get; set; }
        public string? Reason { get; set; }

    }
}
