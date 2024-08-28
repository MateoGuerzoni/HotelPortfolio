using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Filter
{
    public class UserLogueado : Attribute, IAuthorizationFilter

    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Session.GetString("logeado") == null || context.HttpContext.Session.GetString("logeado") == "0")
            {
                context.Result = new RedirectResult("/Usuario/Index");
                return;
            }
        }
    }
}
