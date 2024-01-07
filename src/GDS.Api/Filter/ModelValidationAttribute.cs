using GDS.Api.Model.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace GDS.Api.Filter
{
    public class ModelValidationAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid == false)
            {
                throw new ModelValidationException(context.ModelState);
            }
            base.OnActionExecuting(context);
        }

    }
}
