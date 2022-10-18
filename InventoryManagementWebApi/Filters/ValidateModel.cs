using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace InventoryManagementWebApi.Filters
{
    public class ValidateModel : ActionFilterAttribute
    {
        //The method responds with Bad Request HttpStatus Code with the 
        //Model state validation errors
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                actionContext.Response = actionContext.Request
                    .CreateErrorResponse(HttpStatusCode.BadRequest, actionContext.ModelState);
            }
        }
    }
}
