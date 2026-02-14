using Microsoft.AspNetCore.Mvc;

namespace PhotoSi.Questionnaire.Configuration.Middlewares
{
    /// <summary>
    /// Middleware to handle exceptions in the whole application.
    /// </summary>
    public sealed class GlobalExceptionMiddleware : IMiddleware
    {
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(ILogger<GlobalExceptionMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (context is null || next is null)
            {
                return;
            }

            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception");

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/problem+json";

                var problem = new ProblemDetails
                {
                    Title = "An unexpected error occurred",
                    Status = StatusCodes.Status500InternalServerError
                };

                await context.Response.WriteAsJsonAsync(problem);
            }
        }
    }
}
