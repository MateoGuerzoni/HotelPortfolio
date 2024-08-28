
using LogicaAplicacion.CasoUso.Cabanias;
using LogicaAplicacion.CasoUso.Interfaces;
using LogicaAplicacion.CasoUso.Tipos;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Filter;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApp.Controllers
{
    [UserLogueado]
    public class TipoController : Controller
    {

        private IAltaTipo _altaTipo;
        private IListarTipo _listarTipo;
        private IEditar<Tipo> _editarTipo;
        private IBaja _bajaTipo;
        public TipoController(
            IAltaTipo altaTipo,
            IListarTipo listarTipo,
            IEditar<Tipo> editarTipo,
            IBaja bajaTipo

            )
        {
            _altaTipo = altaTipo;
            _listarTipo = listarTipo;
            _editarTipo = editarTipo;
            _bajaTipo = bajaTipo;

        }

        public ActionResult Index()
        {


            var listaTipos = _listarTipo.ListarTodo();
            if (listaTipos.Count() == 0)
            {
                ViewBag.Message = "No hay tipos para listar";
                return View();
            }
            else
            {
                return View(listaTipos);
            }
        }




        // GET: TipoController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: TipoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tipo tipo)
        {
            try
            {
                _altaTipo.Crear(tipo);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
            }
            return View(tipo);
        }


        public ActionResult Edit(string name)
        {

            try
            {
                Tipo tipo = _listarTipo.ListarUnTipoPorNombre(name);
                return View(tipo);
            }
            catch (Exception)
            {

                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public ActionResult Edit(Tipo tipo)
        {

            try
            {
                _editarTipo.Editar(tipo);
                ViewBag.Success = "Se edito correctamente";

                return View(tipo);

            }
            catch (Exception)
            {
                ViewBag.Error = "Los valores no son correctos";

            }
            return View(tipo);
        }




        public ActionResult Borrar(int id)
        {
            try
            {
                Tipo tipo = _listarTipo.ListarUno(id);
                return View(tipo);
            }
            catch (Exception)
            {

                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public ActionResult Borrar(Tipo tipo)
        {

            try
            {

                _bajaTipo.Borrar(tipo.Id);
                ViewBag.Success = "Se borro correctamente";
                return View(tipo);
            }
            catch (Exception)
            {
                ViewBag.Error = "El tipo esta en uso, no se puede borrar";

            }
            return View(tipo);
        }



        public IActionResult BuscarPorNombre(string nombre)
        {

            try
            {

                if (string.IsNullOrEmpty(nombre))
                {
                    return RedirectToAction("Index");
                }

                IEnumerable<Tipo> tipo = _listarTipo.ListarTipoPorNombre(nombre);
                if (tipo != null && tipo.Count() > 0)
                {
                    return View("Index", tipo);

                }
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Message = "No hay tipos para listar";
            return View("Index");
        }


    }
}
