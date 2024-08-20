using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ITISystem.CustomActionFilter
{
    public class ExceptionsFilter: ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                context.ExceptionHandled = true;
                context.Result= new ContentResult() { Content = "Exception Occurred"};
            }

            base.OnActionExecuted(context);
        }
    }
}
