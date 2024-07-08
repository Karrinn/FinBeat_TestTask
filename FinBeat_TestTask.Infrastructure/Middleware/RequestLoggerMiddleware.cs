using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace FinBeat_TestTask.Infrastructure.Middleware
{
    public class RequestLoggerMiddleware : IMiddleware
    {
        private readonly ILogger<RequestLoggerMiddleware> _logger;

        public RequestLoggerMiddleware(ILogger<RequestLoggerMiddleware> dbLogger)
        {
            _logger = dbLogger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                //var jsonRequest = JsonSerializer.Serialize(context.Request.Body); //todo error here!
                _logger.LogInformation("incomeing request");

                await next(context);
            }
            finally
            {
                //var jsonResponse = JsonSerializer.Serialize(context.Response.Body);
                _logger.LogInformation("outgoing response");
            }
        }
    }
}
