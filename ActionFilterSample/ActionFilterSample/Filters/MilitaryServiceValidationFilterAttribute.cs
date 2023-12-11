using ActionFilterSample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ActionFilterSample.Filters
{
    public class MilitaryServiceValidationFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            var person = context.ActionArguments["person"] as Person;
            if (person != null && person.Gender == 2 && person.MilitaryServiceStatus > 0)
            {
                context.ModelState.AddModelError("MilitaryServiceStatus", " MilitaryServiceStatus for women must be 0");
                var problemDetail = new HttpValidationProblemDetails
                {
                    Detail = "MilitaryServiceStatus for women must be 0",
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetail);
            }
        }
    }
}
