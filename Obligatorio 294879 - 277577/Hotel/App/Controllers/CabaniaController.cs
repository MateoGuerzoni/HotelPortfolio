using LogicaAplicacion.CasoUso.Cabanias;
using LogicaAplicacion.CasoUso.Usuarios;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones;
using Microsoft.AspNetCore.Mvc;


namespace App.Controllers
{
    public class CabaniaController : Controller
    {

  

            private AltaCabania _altaCabania;
            private ListarCabania _listarCabania;
            private BajaCabania _bajaCabania;
            public CabaniaController(
                AltaCabania altaCabania,
                ListarCabania listarCabania,
                BajaCabania bajaCabania

                )
            {
                _altaCabania = altaCabania;
                _bajaCabania = bajaCabania;
                _listarCabania = listarCabania;

            }

            public IActionResult Index(string error)
            {
                ViewBag.Error = error;
                return View();
            }

            //public ActionResult Index()
            //{
            //    return View();
            //}

            //// GET: CabaniaController/Details/5
            //public ActionResult Details(int id)
            //{
            //    return View();
            //}

            //// GET: CabaniaController/Create
            //public ActionResult Create()
            //{
            //    return View();
            //}

            //// POST: CabaniaController/Create
            //[HttpPost]
            //[ValidateAntiForgeryToken]
            //public ActionResult Create(IFormCollection collection)
            //{
            //    try
            //    {
            //        return RedirectToAction(nameof(Index));
            //    }
            //    catch
            //    {
            //        return View();
            //    }
            //}

            //// GET: CabaniaController/Edit/5
            //public ActionResult Edit(int id)
            //{
            //    return View();
            //}

            //// POST: CabaniaController/Edit/5
            //[HttpPost]
            //[ValidateAntiForgeryToken]
            //public ActionResult Edit(int id, IFormCollection collection)
            //{
            //    try
            //    {
            //        return RedirectToAction(nameof(Index));
            //    }
            //    catch
            //    {
            //        return View();
            //    }
            //}

            //// GET: CabaniaController/Delete/5
            //public ActionResult Delete(int id)
            //{
            //    return View();
            //}

            //// POST: CabaniaController/Delete/5
            //[HttpPost]
            //[ValidateAntiForgeryToken]
            //public ActionResult Delete(int id, IFormCollection collection)
            //{
            //    try
            //    {
            //        return RedirectToAction(nameof(Index));
            //    }
            //    catch
            //    {
            //        return View();
            //    }
            //}

            public IActionResult Create()
            {
                return View();
            }

            [HttpPost]
            public IActionResult Create(Cabania cabania)
            {
                try
                {
                    _altaCabania.Crear(cabania);
                    return RedirectToAction("Index");
                }
                catch (NombreCabaniaException e)
                {
                    ViewBag.Error = "El nombre del tema debe tener mas de 2 letras. Por favor intente de nuevo.";
                }
               
                return View(cabania);
            }

        }
    }

