using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System.Diagnostics;
using CS_WebApp.Models;

namespace CS_WebApp.CustomFilters  
{
    public class LogFilterAttribute : ActionFilterAttribute
    {
        IndustryContext ctx;
        public LogFilterAttribute()
        {
            ctx = new IndustryContext();
        }
        private void LogRequest(string currentState, RouteData route)     
        {
            var timeSpan = Stopwatch.StartNew();
            RequestLog requestLog = new RequestLog()
            {
                ControllerName = route.Values["controller"].ToString(),
                ActionName = route.Values["action"].ToString(),
                RequestDateTime = System.DateTime.Now,
                ExecutionCompletionTime = timeSpan.Elapsed.TotalMilliseconds.ToString(),
            };
            ctx.RequestLogs.Add(requestLog);
            ctx.SaveChanges();
        }
        //private void LogRequest(string currentState, RouteData route)
        //{
        //    string message = $"Current State {currentState} for Exeuting Controller is {route.Values["controller"].ToString()} and Action is {route.Values["action"].ToString()}";
        //    //Debug.WriteLine(message);
        //}

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            LogRequest("OnActionExecuting", context.RouteData);
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            LogRequest("OnActionExecuted", context.RouteData);
        }
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            LogRequest("OnResultExecuting", context.RouteData);
        }
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            LogRequest("OnResultExecuted", context.RouteData);
        }
    }
}
