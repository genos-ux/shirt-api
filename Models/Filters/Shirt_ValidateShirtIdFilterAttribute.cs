using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using shirt_api.Models.Repositories;



namespace shirt_api.Models.Filters;

public class Shirt_ValidateShirtIdFilterAttribute:ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);

        var shirtId = context.ActionArguments["id"] as int?;

        if(shirtId.HasValue)
        {
            if(shirtId.Value <= 0)
            {
                context.ModelState.AddModelError("ShirtId","ShirtId is invalid.");
                context.Result = new BadRequestObjectResult(context.ModelState);


            }

            else if(!ShirtRepository.ShirtExists(shirtId.Value))
            {
                context.ModelState.AddModelError("ShirtId","ShirtId doesn't exist.");
                context.Result = new NotFoundObjectResult(context.ModelState);
            }
        }


    }
}
