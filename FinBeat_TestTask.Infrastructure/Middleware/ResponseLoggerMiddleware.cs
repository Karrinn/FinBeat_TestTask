using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace FinBeat_TestTask.Infrastructure.Middleware
{
    public class ResponseLoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ResponseLoggerMiddleware> _logger;

        public ResponseLoggerMiddleware(RequestDelegate next, ILogger<ResponseLoggerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var bodyStream = context.Response.Body;

            var responseBodyStream = new MemoryStream();
            context.Response.Body = responseBodyStream;

            await _next(context);

            responseBodyStream.Seek(0, SeekOrigin.Begin);
            var responseBody = new StreamReader(responseBodyStream).ReadToEnd();

            _logger.Log(LogLevel.Information, 1, $"RESPONSE LOG: {responseBody}", null, (state, exception) => state);

            responseBodyStream.Seek(0, SeekOrigin.Begin);
            await responseBodyStream.CopyToAsync(bodyStream);
        }
    }
}
