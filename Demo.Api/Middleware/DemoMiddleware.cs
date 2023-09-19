namespace Demo.Api.Middleware
{
    public class DemoMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<DemoMiddleware> logger;
        public DemoMiddleware(RequestDelegate requestDelegate, ILogger<DemoMiddleware> logger)
        {
            next = requestDelegate;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            //Logic
            logger.LogInformation("Custome");
            await next(context);
            logger.LogInformation("end Custome");
            // Logic
        }
    }
}
