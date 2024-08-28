using AppCliente.Filter;
using AppCliente.Models;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Drawing;
using System.Text.Json;
using System.Xml.Linq;

namespace AppCliente.Controllers
{
    [UsuarioLogueado]

    public class TipoController : Controller
    {


        private string localHost = "https://localhost:7215";
        public IActionResult Index()
        {
            try
            {
                var client = new RestClient(localHost);
                var request = new RestRequest("/api/Tipos");
                RestResponse response = client.ExecuteGet(request);
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true,
                };

                if (response.IsSuccessStatusCode)
                {
                    var tipos = JsonSerializer.Deserialize<List<VMTipo>>(response.Content, options);
                    return View(tipos);
                }
                else
                {
                    ViewBag.ErrorMessage = "Hubo un error al obtener los tipos de cabanias.";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error inesperado, intente de nuevo mas tarde";
                return View();
            }
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VMTipo unTipo)
        {
            try
            {
                var client = new RestClient(localHost);

                var request = new RestRequest("api/Tipos");
                request.AddHeader("Authorization", "Bearer " + Utilidades.obtenerToken(HttpContext));
                request.AddHeader("Content-Type", "application/json");

                VMTipo tipo = new VMTipo()
                {
                    Nombre = unTipo.Nombre,
                    Descripcion = unTipo.Descripcion,
                    CostoPorHuesped = unTipo.CostoPorHuesped
                };
                request.AddJsonBody(tipo);

                RestResponse response = client.ExecutePost(request);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {

                    ViewBag.ErrorMessage = "Hubo un error al crear el tipo de cabania.";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Hubo un error inesperado.";
                return View();
            }
        }

        public IActionResult Edit(string name)
        {
            VMTipo tipo = obtenerTiposPorNombre(name);
            return View(tipo);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, VMTipo unTipo)
        {
            try
            {
                var client = new RestClient(localHost);

                var request = new RestRequest("api/Tipos/" + id.ToString());
                request.AddHeader("Authorization", "Bearer " + Utilidades.obtenerToken(HttpContext));
                request.AddHeader("Content-Type", "application/json");

                VMTipo tipo = new VMTipo()
                {
                    Id = id,
                    Nombre = unTipo.Nombre,
                    Descripcion = unTipo.Descripcion,
                    CostoPorHuesped = unTipo.CostoPorHuesped
                };

                request.AddJsonBody(tipo);
                RestResponse response = client.ExecutePut(request);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ErrorMessage = "Hubo un error al editar el tipo de cabania.";
                    return View(unTipo);
                }
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "Hubo un error inesperado.";
                return View("Index");
            }
        }

        public IActionResult Delete(string name)
        {
            VMTipo tipo = obtenerTiposPorNombre(name);
            return View(tipo);

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            try
            {
                var client = new RestClient(localHost);

                var request = new RestRequest("api/Tipos/" + id.ToString());
                request.AddHeader("Authorization", "Bearer " + Utilidades.obtenerToken(HttpContext));
                request.AddHeader("Content-Type", "application/json");
                RestResponse response = client.Delete(request);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ErrorMessage = "Hubo un error al borrar el tipo de cabania.";
                    return View();
                }

            }
            catch
            {
                ViewBag.ErrorMessage = "Hubo un error al borrar el tipo de cabania.";
                return View();
            }
        }

        public VMTipo obtenerTiposPorNombre(string nombre)
        {

            var client = new RestClient(localHost);
            var request = new RestRequest("/api/Tipos/name/" + nombre);

            RestResponse response = client.ExecuteGet(request);
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };


            VMTipo tipo = JsonSerializer.Deserialize<VMTipo>(response.Content, options);
            return tipo;

        }

        public IActionResult BuscarTiposPorNombre(string? nombre)
        {
            try
            {

                if (string.IsNullOrEmpty(nombre))
                {
                    return RedirectToAction("Index");
                }
                
                var client = new RestClient(localHost);
                var request = new RestRequest("/api/Tipos/name/" + nombre);
                request.AddHeader("Authorization", "Bearer " + Utilidades.obtenerToken(HttpContext));
                request.AddHeader("Content-Type", "application/json");
                RestResponse response = client.ExecuteGet(request);
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true,
                };
                if (response.IsSuccessStatusCode)
                {
                    //string strTipos = response.Content;
                    var tipos = JsonSerializer.Deserialize<VMTipo>(response.Content, options);
                    string name = tipos.Nombre;
                    return RedirectToAction("Delete", new { name = name });
                }
                else
                {
                    ViewBag.ErrorMessage = "Error al buscar cabañas por nombre.";
                    return View("Index");
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "No hay ningun tipo con ese nombre.";
                return View("Index");
            }

            
        }

    }
}
