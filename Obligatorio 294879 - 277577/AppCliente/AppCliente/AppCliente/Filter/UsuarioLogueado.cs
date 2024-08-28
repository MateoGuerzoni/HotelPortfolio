using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using AppCliente.Models;
using System.Text.Json;

namespace AppCliente.Filter
{
    public class UsuarioLogueado : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Session.GetString("usuarioLogueado") == null)
            {
                context.Result = new RedirectResult("/Usuario/Login");
            }
            
           
        }
    }
}
