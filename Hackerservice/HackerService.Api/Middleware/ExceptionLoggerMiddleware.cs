namespace HackerService.Api.Middleware
{
    public class ExceptionLoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionLoggerMiddleware> _logger;

        public ExceptionLoggerMiddleware(RequestDelegate next
            //, 
            //ILogger<ExceptionLoggerMiddleware> logger
            )
        {
            _next = next;
            //_logger = logger;
        }

        public Task Invoke(HttpContext httpContext)
        {
            var result = _next(httpContext);
            if (result.Status == TaskStatus.Faulted)
            {
                //_logger.LogError("Somehting went wrong!");//TODO: add more info
                return Task.FromResult(Results.StatusCode(500));
            }
            return result;
           
        }
    }
}
