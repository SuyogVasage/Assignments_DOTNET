namespace WebAPI.CustomMiddleware
{
    public class ExceptionMiddleware
    {
        public readonly RequestDelegate next;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ExceptionMiddleware(RequestDelegate request)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            next = request;
        }
        /// <summary>
        /// The Method the contains the Middlweare logic
        /// Current Middleware will use try..catch block since it is used for exception handling 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private ApiDbContext ctx;
        public async Task InvokeAsync(HttpContext context, ApiDbContext ctx)
        {
            this.ctx = ctx;
            try
            {
                // If no Error then move to next midleware
                await next(context);
            }
            catch (Exception ex)
            {
                // Else Handle an exception and return HTTP Response
                // 1. Set the Statuc code
               // context.Response.StatusCode = 500;
                // 2. Read the exception MEssage
                string message = ex.Message;
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string stacktrace = ex.StackTrace;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

                // 3. Set this information to ErrorInfo class
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                var excepetionLog = new ExceptionLog()
                {
                    //ErrorCode = context.Response.StatusCode,
                    ErrorMessage = message,
                    RequestDateTime = DateTime.Now,
                    StackTrace = stacktrace,
                    RequestMethodType = context.Request.Method,
                    //ControllerName Not found
                    ControllerName = context.GetRouteValue("controller").ToString()
                };
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                var res = await ctx.ExceptionLogs.AddAsync(excepetionLog);
                ctx.SaveChanges();
                // 4. Write the ErrorInfo object into the Response
                // with JSON Serialization
                await context.Response.WriteAsJsonAsync<ExceptionLog>(excepetionLog);
            }
        }
    }

    /// <summary>
    /// AN Extension CLass that provides an extension method
    /// For Registering Custom Middleare into the Http Pipeline  
    /// </summary>
    public static class ErrorInfoExtensions
    {
        public static void UseRequestException(this IApplicationBuilder builder)  
        {
            // Registering the CLass as Custom Middleware
            // so that it can be used in Pipeline
            builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}

