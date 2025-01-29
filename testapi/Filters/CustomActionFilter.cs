using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace testapi.Filters
{
    public class CustomActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            WriteLine($"Action is executing {context.ActionDescriptor.DisplayName}");
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            WriteLine($"Action is executed {context.ActionDescriptor.DisplayName}");
        }


    }
}