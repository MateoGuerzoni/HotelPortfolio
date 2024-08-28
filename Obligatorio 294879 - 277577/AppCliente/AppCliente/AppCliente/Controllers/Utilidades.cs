using AppCliente.Models;
using System.Text.Json;

namespace AppCliente.Controllers
{
    public static class Utilidades
    {

        public static string obtenerToken(HttpContext httpcontext)
        {
            var session = httpcontext.Session;
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            VMUsuarioLogueado usuarioLogueado = JsonSerializer.Deserialize<VMUsuarioLogueado>(session.GetString("usuarioLogueado"), options);
            string token = usuarioLogueado.Token;
            return token;
        }
    }
}
