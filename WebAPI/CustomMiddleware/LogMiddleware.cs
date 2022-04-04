namespace WebAPI.CustomMiddleware
{
    public class LogMiddleware
    {
        public readonly RequestDelegate next;
        private ApiDbContext ctx;
        public LogMiddleware(RequestDelegate request)
        {
            next = request;
        }
        /// <summary>
        /// The Method the contains the Middlweare logic
        /// Current Middleware will use try..catch block since it is used for exception handling
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context, ApiDbContext ctx)
        {
            await next(context);
            this.ctx = ctx;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            RequestLog log = new RequestLog()
            {
                ControllerName = context.GetRouteValue("controller").ToString(),
                //ControllerName = route.Values["controller"].ToString(),
                RequestMethodType = context.Request.Method.ToString(),
                RequestDateTime = System.DateTime.Now,
            };
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            await ctx.RequestLogs.AddAsync(log);
            ctx.SaveChanges();
        }
    }
    /// <summary>
    /// AN Extension CLass that provides an extension method
    /// For Registering Custom Middleare into the Http Pipeline
    /// </summary>
    public static class LogInfoExtensions
    {
        public static void UseLogRequest(this IApplicationBuilder builder)  
        {
            // Registering the CLass as Custom Middleware
            // so that it can be used in Pipeline
            builder.UseMiddleware<LogMiddleware>();
        }
    }
}
