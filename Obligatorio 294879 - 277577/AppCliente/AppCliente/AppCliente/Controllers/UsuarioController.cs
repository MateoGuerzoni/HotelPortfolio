using System.Web;
using Microsoft.AspNetCore.Mvc;
using AppCliente.Models;
using RestSharp;
using System.Text.Json;
using System.Net;

namespace AppCliente.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public IActionResult Login(VMUsuario usuarioModel)
        {
            try
            {
                var client = new RestClient("https://localhost:7215");
                var request = new RestRequest("/api/Usuarios/Login", Method.Post);
                request.AddHeader("Content-Type", "application/json");
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                };

                string json = JsonSerializer.Serialize(usuarioModel, options);

                request.AddJsonBody(json);

                RestResponse response = client.Execute(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string jsonResponse = response.Content;
                    HttpContext.Session.SetString("usuarioLogueado", jsonResponse);
                    return RedirectToAction("Index", "Cabania");
                }
                else
                {
                    // Manejo de error en el login
                    TempData["ErrorLogin"] = "Credenciales inválidas";
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                TempData["ErrorLogin"] = "Ocurrió un error en el servidor";
            }

            return View("Login");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/Usuario/Login");
        }

        

    }
}
