using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testapi.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly ILogger _logger;   // ILogger is a type that can be used to log messages
        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation($"Request: {context.Request.Method} {context.Request.Path}");
            await _next(context);
            _logger.LogInformation  ($"Response: {context.Response.StatusCode}");
        }
    }
}