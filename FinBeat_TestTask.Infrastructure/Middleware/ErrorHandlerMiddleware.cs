using FinBeat_TestTask.Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace FinBeat_TestTask.Infrastructure.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());

                // can be done via exceptionToResponseMapper
                ExceptionResponse exResponse = e switch
                {
                    // Customize exception here
                    AppException ex => new ExceptionResponse(StatusCodes.Status400BadRequest, ex.Code, ex.Message),
                    _ => new ExceptionResponse(StatusCodes.Status400BadRequest, "unexpected_error")
                };

                var jsonResponse = JsonSerializer.Serialize(new { code = exResponse.Code, message = exResponse.Reason });
                context.Response.StatusCode = exResponse.StatusCode;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(jsonResponse);
            }
        }
    }
}
