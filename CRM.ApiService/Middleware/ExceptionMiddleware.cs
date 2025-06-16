using System.Text.Json;

namespace CRM.ApiService.Middleware
{
    public class ExceptionMiddleware
    {


        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddleware> logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context); 
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unhandled exception occurred while processing request: {path}", context.Request.Path);

                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";

                var errorResponse = new
                {
                    error = "Internal Server Error",
                    details = ex.Message 
                };

                var json = JsonSerializer.Serialize(errorResponse);
                await context.Response.WriteAsync(json);
            }
        }

    }
}
