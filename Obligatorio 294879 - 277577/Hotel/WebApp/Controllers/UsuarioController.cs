using LogicaAplicacion.CasoUso.Interfaces;
using LogicaAplicacion.CasoUso.Usuarios;
using LogicaNegocio.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Controllers
{
    public class UsuarioController : Controller
    {


        private IAltaUsuario _altaUsuario;
        private IBaja _bajaUsuario;
        private IBuscarUsuario _buscarUsuario;
        private IValidarUsuario _validarUsuario;
        public UsuarioController(
            IAltaUsuario altaUsuario,
            IBaja bajaUsuario,
            IBuscarUsuario buscarUsuario,
            IValidarUsuario validarUsuario
            )
        {
            _altaUsuario = altaUsuario;
            _bajaUsuario = bajaUsuario;
            _buscarUsuario = buscarUsuario;
            _validarUsuario = validarUsuario;
        }


        public IActionResult Index(string error)
        {
            ViewBag.Error = error;


            return View();
        }

        public IActionResult Login()
        {


            return View("Index");


        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            try
            {
                if (_validarUsuario.ValidarEmailContrasenia(email, password))
                {
                    HttpContext.Session.SetString("logeado", "1");
                    if (email != null)
                    {
                        return Redirect("/Cabania/Index");
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View("Index");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.SetString("logeado", "0");
            return Redirect("/Usuario/Index");
        }

        public IActionResult PrecargaUsers()
        {
            try
            {
                _altaUsuario.PrecargaUsers();
                return View("Index");
            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message; ;
            }
            return View("Index");
        }


    }
}
