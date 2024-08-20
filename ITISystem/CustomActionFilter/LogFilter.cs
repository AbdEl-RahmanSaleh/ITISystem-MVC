using Humanizer;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace ITISystem.CustomActionFilter
{
    public class LogFilter : ActionFilterAttribute
    {
        Stopwatch sp = new Stopwatch();
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            sp.Start();
            Debug.WriteLine("Action Start"); 
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {   
            sp.Stop();
            Debug.WriteLine($"{sp.ElapsedMilliseconds}"); 
            base.OnActionExecuted(context);
        }
        
        
    }
}
