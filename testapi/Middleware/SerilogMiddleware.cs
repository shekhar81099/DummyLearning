using Serilog;

namespace testapi.Middleware
{
    public class SerilogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly Serilog.ILogger _logger;  // ILogger is a type that can be used to log messages
        public SerilogMiddleware(RequestDelegate next)
        {
            _next = next;
            _logger = Log.ForContext<SerilogMiddleware>();
        }
        public async Task InvokeAsync(HttpContext context)
        {
            // Log the incoming request details
            _logger.Information("Incoming Request: {Method} {Path} {QueryString}",
                context.Request.Method,
                context.Request.Path,
                context.Request.QueryString);

            var startTime = DateTime.UtcNow; // Track the start time for request processing

            await _next(context); // Pass the request to the next middleware

            var duration = DateTime.UtcNow - startTime; // Calculate the request processing time

            // Log the outgoing response details
            _logger.Information("Outgoing Response: {StatusCode} in {Duration}ms",
                context.Response.StatusCode,
                duration.TotalMilliseconds);
        }
    }
}