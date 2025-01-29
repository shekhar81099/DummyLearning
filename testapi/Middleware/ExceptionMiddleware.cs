using System.Text.Json;
using Serilog;

namespace testapi.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly Serilog.ILogger _logger;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
            _logger = Log.ForContext<ExceptionMiddleware>();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                // Log the exception details
                _logger.Error(ex, "An unhandled exception has occurred");

                context.Response.StatusCode = 500; // Set the status code to 500 (Internal Server Error)
                context.Response.ContentType = "application/json"; // Set the content type to JSON

                // Write the error message to the response body
                await context.Response.WriteAsync(JsonSerializer.Serialize(new
                {
                    StatusCode = context.Response.StatusCode,
                    Message = "Internal Server Error"
                }));
            }
        }
    }
}