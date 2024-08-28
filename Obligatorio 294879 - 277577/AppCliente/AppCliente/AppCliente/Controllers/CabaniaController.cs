using AppCliente.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RestSharp;
using System.Globalization;
using System.Text.Json;
using AppCliente.Filter;


using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.DotNet.MSIdentity.Shared;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace AppCliente.Controllers
{
    [UsuarioLogueado]

    public class CabaniaController : Controller
    {
        private string localHost = "https://localhost:7215";
        
        
        public IActionResult Index()
        {
            try
            {
                ViewBag.Tipos = obtenerTipos();

                var client = new RestClient(localHost);
                var request = new RestRequest("/api/Cabanias");
                RestResponse response = client.ExecuteGet(request);
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true,
                };
                if (response.IsSuccessStatusCode)
                {
                    var cabanias = JsonSerializer.Deserialize<List<VMCabania>>(response.Content, options);
                    return View(cabanias);
                }
                else
                {
                    ViewBag.ErrorMessage = "Error al obtener los datos de las cabañas.";
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Ocurrió un error durante la ejecución: " + ex.Message;
            }

            return View(nameof(Index));
        }

        public IActionResult BuscarPorNombre(string? nombre)
        {
            try
            {
                ViewBag.Tipos = obtenerTipos();

                if (string.IsNullOrEmpty(nombre))
                {
                    return RedirectToAction("Index");
                }

                var client = new RestClient(localHost);
                var request = new RestRequest("/api/Cabanias/name/" + nombre);
                RestResponse response = client.ExecuteGet(request);
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true,
                };
                if (response.IsSuccessStatusCode)
                {
                    var cabanias = JsonSerializer.Deserialize<List<VMCabania>>(response.Content, options);
                    return View("Index", cabanias);
                }
                else
                {
                    ViewBag.ErrorMessage = "No hay cabanias que cumplan este filtro.";
                    return View("Index");

                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Ocurrió un error durante la ejecución: " + ex.Message;
            }

            return RedirectToAction("Index");
        }


        public IActionResult BuscarPorTipo(string? nombreTipo)
        {
            try
            {
                ViewBag.Tipos = obtenerTipos();

                if (string.IsNullOrEmpty(nombreTipo))
                {
                    return RedirectToAction("Index");
                }

                var client = new RestClient(localHost);
                var request = new RestRequest("/api/Cabanias/tipo/" + nombreTipo);
                RestResponse response = client.ExecuteGet(request);
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true,
                };

                if (response.IsSuccessStatusCode)
                {
                    var cabanias = JsonSerializer.Deserialize<List<VMCabania>>(response.Content, options);
                    return View("Index", cabanias);
                }
                else
                {
                    ViewBag.ErrorMessage = "No hay cabanias que cumplan este filtro.";
                    return View("Index");

                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Ocurrió un error durante la ejecución: " + ex.Message;
            }

            return RedirectToAction("Index");
        }


        public IActionResult BuscarPorCantidadMax(int maxHuespedes)
        {
            try
            {
                ViewBag.Tipos = obtenerTipos();

                var client = new RestClient(localHost);
                var request = new RestRequest("api/Cabanias/huespedes/" + maxHuespedes);
                RestResponse response = client.ExecuteGet(request);
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true,
                };

                if (maxHuespedes < 0)
                {
                    return RedirectToAction("Index");
                }

                if (response.IsSuccessStatusCode)
                {
                    var cabanias = JsonSerializer.Deserialize<List<VMCabania>>(response.Content, options);
                    return View("Index", cabanias);
                }
                else
                {
                    ViewBag.ErrorMessage = "No hay cabanias que cumplan este filtro.";
                    return View("Index");

                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Ocurrió un error durante la ejecución: " + ex.Message;
            }

            return RedirectToAction("Index");
        }


        public IActionResult BuscarPorEstado(bool estado)
        {
            ViewBag.Tipos = obtenerTipos();

            if (estado!= null)
            {
                var client = new RestClient(localHost);
                var request = new RestRequest("api/Cabanias/estado/" + estado);
                RestResponse response = client.ExecuteGet(request);
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true,
                };

                if (response.IsSuccessStatusCode)
                {
                    var cabanias = JsonSerializer.Deserialize<List<VMCabania>>(response.Content, options);
                    return View("Index", cabanias);
                }
                else
                {
                    ViewBag.ErrorMessage = "No hay cabanias que cumplan este filtro.";
                    return View("Index");

                }
            }

            return RedirectToAction("Index");
        }

        public IActionResult Consulta1(int monto)
        {
            ViewBag.Tipos = obtenerTipos();

            if (monto!= null)
            {
                var client = new RestClient(localHost);
                var request = new RestRequest("api/Cabanias/" + monto);
                RestResponse response = client.ExecuteGet(request);
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true,
                };

                if (response.IsSuccessStatusCode)
                {
                    var cabanias = JsonSerializer.Deserialize<List<VMCabania>>(response.Content, options);
                    return View("Index", cabanias);
                }
                else
                {
                    ViewBag.ErrorMessage = "No hay cabanias que cumplan este filtro.";
                    return View("Index");

                }
            }
            return RedirectToAction("Index");
        }


        public IEnumerable<VMTipo> obtenerTipos()
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
                    IEnumerable<VMTipo> lista = JsonSerializer.Deserialize<IEnumerable<VMTipo>>(response.Content, options);
                    return lista;
                }
                else
                {
                    return Enumerable.Empty<VMTipo>();
                }
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<VMTipo>();
            }
        }

        public VMTipo obtenerTiposPorNombre(string nombre)
        {
            try
            {
                var client = new RestClient(localHost);
                var request = new RestRequest("/api/Tipos/name/" + nombre);
                RestResponse response = client.ExecuteGet(request);
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true,
                };

                if (response.IsSuccessStatusCode)
                {
                    VMTipo tipo = JsonSerializer.Deserialize<VMTipo>(response.Content, options);
                    return tipo;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public VMCabania obtenerCabaniaPorID(int id)
        {
            try
            {
                var client = new RestClient(localHost);
                var request = new RestRequest("/api/Cabanias/id/" + id);
                RestResponse response = client.ExecuteGet(request);
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true,
                };

                if (response.IsSuccessStatusCode)
                {
                    VMCabania cabania = JsonSerializer.Deserialize<VMCabania>(response.Content, options);
                    return cabania;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public IActionResult Create()
        {

            ViewBag.Tipos = obtenerTipos();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VMCabania vMCabania, string nombreTipo)
        {
            try
            {
                ViewBag.Tipos = obtenerTipos();

                VMTipo vMTipo = obtenerTiposPorNombre(nombreTipo);
                vMCabania.TipoId = vMTipo.Id;
                var client = new RestClient(localHost);
                var request = new RestRequest("/api/Cabanias");
                request.AddHeader("Authorization", "Bearer " + Utilidades.obtenerToken(HttpContext)); request.AddHeader("Content-Type", "application/json");
                string p = JsonSerializer.Serialize(vMCabania);
                request.AddBody(p);
                RestResponse response = client.ExecutePost(request);

                if (response.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
                else
                {

                    ViewBag.ErrorMessage = "Error al crear la cabaña.";
                    return View(vMCabania);
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error inesperado, intente de nuevo mas tarde";
                return View(vMCabania);
            }
        }


        public IActionResult AgregarMantenimiento(int id)
        {


            VMCabania cabania = obtenerCabaniaPorID(id);
            ViewBag.idCabania = id;
            return View();


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AgregarMantenimiento(VMMantenimiento mant, int IdCabania)
        {
            try
            {
                //VMCabania cabania = obtenerCabaniaPorID(IdCabania);

                mant.CabaniaId= IdCabania;

                var client = new RestClient(localHost);
                var request = new RestRequest("/api/Cabanias/mantenimiento/" + IdCabania);
                request.AddHeader("Authorization", "Bearer " + Utilidades.obtenerToken(HttpContext)); request.AddHeader("Content-Type", "application/json");
                string p = JsonSerializer.Serialize(mant);
                request.AddBody(p);
                RestResponse response = client.ExecutePost(request);

                if (response.IsSuccessStatusCode)
                {
                    // Procesar la respuesta exitosa según corresponda
                    // Por ejemplo, redireccionar a la vista de éxito o mostrar un mensaje de éxito
                    return RedirectToAction("Index");
                }
                else
                {

                    ViewBag.ErrorMessage = "Error al agregar el mantenimiento.";
                    ViewBag.idCabania = IdCabania;
                    return View(mant);
                    
                }
            }
            catch (Exception ex)
            {

                ViewBag.ErrorMessage = "Error inesperado, intente de nuevo mas tarde";
                return View(mant);
            }
        }


        public IActionResult VerMantenimiento(int id)
        {
            try
            {
                ViewBag.id = id;
                VMCabania cabania = obtenerCabaniaPorID(id);

                var client = new RestClient(localHost);
                var request = new RestRequest("/api/Cabanias/mantenimiento/" + id);
                RestResponse response = client.ExecuteGet(request);
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true,
                };

                if (response.IsSuccessStatusCode)
                {
                    IEnumerable<VMMantenimiento> lista = JsonSerializer.Deserialize<IEnumerable<VMMantenimiento>>(response.Content, options);
                    return View(lista);
                }
                else
                {
                    ViewBag.ErrorMessage = "Hubo un error al obtener los mantenimientos.";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Hubo un error inesperado.";
                return View();
            }
        }


        public IActionResult BuscarPorFecha(int id, DateTime Fecha1, DateTime Fecha2)
        {
            ViewBag.Id = id;


            string FechaI = Fecha1.ToString("yyyy-MM-ddTHH:mm:ss.fffffff");
            string FechaF = Fecha2.ToString("yyyy-MM-ddTHH:mm:ss.fffffff");
            var client = new RestClient(localHost);
            var request = new RestRequest("api/Cabanias/mantenimiento/" + id + "," + FechaI + "," + FechaF);
            RestResponse response = client.ExecuteGet(request);
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };
            if (response.IsSuccessStatusCode)
            {
                var mantenimientos = JsonSerializer.Deserialize<List<VMMantenimiento>>(response.Content, options);
                return View("VerMantenimiento", mantenimientos);
            }
            else
            {
                ViewBag.ErrorMessage = "No hay mantenimientos entre estas fechas.";
                return View("VerMantenimiento");
            }
            

        }

        public IActionResult VerMantenimientoPorPersona(int min, int max)
        {
            if (min != 0)
            {
                var client = new RestClient(localHost);
                var request = new RestRequest("api/Cabanias/" + min + "," + max);
                RestResponse response = client.ExecuteGet(request);
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true,
                };
                if (response.IsSuccessStatusCode)
                {
                    var mantenimientos = JsonSerializer.Deserialize<List<VMMantenimientoPorPersona>>(response.Content, options);
                    return View(mantenimientos);
                }
                else
                {
                    ViewBag.ErrorMessage = "No hay nada pa";
                    return View();
                }

            }
            return View();

        }
    
    }


}
