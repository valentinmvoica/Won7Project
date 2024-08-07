using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Won7Project.Exceptions;

namespace Won7Project.MiddlewareFilters
{
    public class CustomExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order => int.MaxValue-10;

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is IdNotFoundException)
            {
                context.Result = new ObjectResult(context.Exception.Message)
                {
                    StatusCode = StatusCodes.Status404NotFound
                };

                context.ExceptionHandled = true;

            }
            //else if (context.Exception is NullReferenceException)
            //{
            //    context.Result = new ObjectResult(context.Exception.Message)
            //    {
            //        StatusCode = StatusCodes.Status503ServiceUnavailable
            //    };

            //    context.ExceptionHandled = true;
            //}
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
