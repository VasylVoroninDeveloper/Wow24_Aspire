namespace CRM.ApiService.Middleware
{
    public class LoggingMiddleware
    {

        private readonly RequestDelegate next;
        private readonly ILogger<LoggingMiddleware> logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Request.EnableBuffering();
            var requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();
            context.Request.Body.Position = 0;

            logger.LogInformation("HTTP Request: {method} {url} \nHeaders: {headers} \nBody: {body}",
            context.Request.Method,
            context.Request.Path,
            context.Request.Headers,
            requestBody);

            var originalBodyStream = context.Response.Body;
            using var responseBody = new MemoryStream();
            context.Response.Body = responseBody;

            await next(context); 

            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var responseText = await new StreamReader(context.Response.Body).ReadToEndAsync();
            context.Response.Body.Seek(0, SeekOrigin.Begin);

            logger.LogInformation("HTTP Response: {statusCode} \nHeaders: {headers} \nBody: {body}",
            context.Response.StatusCode,
            context.Response.Headers,
            responseText);

            await responseBody.CopyToAsync(originalBodyStream);
        }

    }
}
