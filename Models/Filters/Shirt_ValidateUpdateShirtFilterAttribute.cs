using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using shirt_api.Models.Repositories;



namespace shirt_api.Models.Filters;

public class Shirt_ValidateUpdateShirtFilterAttribute:ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);

        var id = context.ActionArguments["id"] as int?;
        var shirt = context.ActionArguments["shirt"] as Shirt;

        if(id.HasValue && shirt != null && shirt.ShirtId != id.Value)
        {
            context.ModelState.AddModelError("ShirtId","ShirtId is not the same as id.");
            var problemDetails = new ValidationProblemDetails(context.ModelState)
            {
                Status = StatusCodes.Status400BadRequest
            };
            context.Result = new BadRequestObjectResult(problemDetails);
        }

    }
}
