using LogicaAplicacion.CasoUso.Interfaces;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Filter;

namespace WebApp.Controllers
{
    [UserLogueado]
    public class CabaniaController : Controller
    {



        private IAltaCabania _altaCabania;
        private IListarCabania _listarCabania;
        private IBaja _bajaCabania;
        private IListarTipo _listarTipo;
        private IWebHostEnvironment _environment;


        public CabaniaController(
            IAltaCabania altaCabania,
            IListarCabania listarCabania,
            IBaja bajaCabania,
            IListarTipo listarTipo,
            IWebHostEnvironment environment

            )
        {
            _altaCabania = altaCabania;
            _bajaCabania = bajaCabania;
            _listarCabania = listarCabania;
            _listarTipo = listarTipo;
            _environment = environment;


        }

        public IActionResult Index(string error)
        {

            ViewBag.Message = "No hay Cabañas para listar";
            ViewBag.Tipos = _listarTipo.ListarTodo();
            ViewBag.Error = error;
            return View(_listarCabania.ListarTodo());
        }

        public IActionResult BuscarPorNombre(string? nombre)
        {

            ViewBag.Tipos = _listarTipo.ListarTodo();
            if (string.IsNullOrEmpty(nombre))
            {
                return RedirectToAction("Index");
            }
            return View("Index", _listarCabania.ListarCabaniasNombre(nombre));
        }


        public IActionResult BuscarPorTipo(string? NombreTipo)
        {

            ViewBag.Tipos = _listarTipo.ListarTodo();
            if (string.IsNullOrEmpty(NombreTipo))
            {
                return RedirectToAction("Index");
            }

            return View("Index", _listarCabania.ListarCabaniaPorTipo(NombreTipo));
        }

        public IActionResult BuscarPorCantidadMax(int MaxHuespedes)
        {

            ViewBag.Tipos = _listarTipo.ListarTodo();
            if (int.IsNegative(MaxHuespedes))
            {
                return RedirectToAction("Index");
            }

            return View("Index", _listarCabania.ListarCabaniaPorHuespedes(MaxHuespedes));
        }

        public IActionResult BuscarPorEstado(bool estado)
        {

            ViewBag.Tipos = _listarTipo.ListarTodo();
            if (estado == null)
            {
                return RedirectToAction("Index");
            }

            return View("Index", _listarCabania.ListarCabaniaPorEstado(estado));

        }



        public IActionResult Create()
        {

            ViewBag.Tipos = _listarTipo.ListarTodo();
            return View();
        }

        [HttpPost]
        public IActionResult Create(ViewModelCabania VMcabania, string NombreTipo)
        {
            try
            {
                VMcabania.Tipo = _listarTipo.ListarUnTipoPorNombre(NombreTipo);
                //int numHabitacionObt = _altaCabania.ObtenerNumHabitacion();


                string extension = Path.GetExtension(VMcabania.Imagen.FileName);
                if (extension == ".jpg" || extension == ".png" || extension == ".jpeg")
                {
                    string numString = "001";
                    string nombreCabania = VMcabania.Nombre.Replace(" ", "_");
                    string nombreFoto = numString + "_" + nombreCabania + ".jpg";


                    string rutaImagenes = Path.Combine(_environment.WebRootPath + "\\imagenes\\", nombreFoto);

                    FileStream foto = new FileStream(rutaImagenes, FileMode.Create);
                    VMcabania.Imagen.CopyTo(foto);

                    Cabania cabania = new Cabania()
                    {
                        //numHabitacion = numHabitacionObt + 1,
                        Tipo = VMcabania.Tipo,
                        Nombre = VMcabania.Nombre,
                        Descripcion = VMcabania.Descripcion,
                        TieneJacuzzi = VMcabania.TieneJacuzzi,
                        Estado = VMcabania.Estado,
                        MaxHuespedes = VMcabania.MaxHuespedes,
                        Foto = nombreFoto
                    };
                    _altaCabania.Crear(cabania);
                }
                else
                {
                    throw new Exception("Error en el formato de la imagen.");
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;

            }
            ViewBag.Tipos = _listarTipo.ListarTodo();
            return View(VMcabania);
        }

        public IActionResult AgregarMantenimiento(int id)
        {

            try
            {
                Cabania cabania = _listarCabania.ListarUna(id);
                ViewBag.idCabania = id;
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Index", new { error = "No se encontró " + id });
            }

        }

        [HttpPost]
        public IActionResult AgregarMantenimiento(Mantenimiento mant, int IdCabania)
        {

            try
            {
                Cabania cabania = _listarCabania.ListarUna(IdCabania);
                if (_listarCabania.ListarMantenimientosDiarios(cabania).Count() >= 3)
                {

                    return RedirectToAction("AgregarMantenimiento", ViewBag.idCabania = IdCabania, ViewBag.Error = "No es posible hacer mas de 3 mantenimientos el mismo dia");
                }
                mant.CabaniaRealizada = _listarCabania.ListarUna(IdCabania);


                _altaCabania.CrearMantenimineto(mant);


                return RedirectToAction("AgregarMantenimiento", ViewBag.idCabania = IdCabania, ViewBag.Success = "Exito");
            }
            catch (Exception e)

            {
                //Arreglar esto para la proxima entrega
                if (ViewBag.Error == "No es posible hacer mas de 3 mantenimientos el mismo dia")
                {
                    ViewBag.error = "No es posible hacer mas de 3 mantenimientos el mismo dia";
                }
                else if (ViewBag.Success == "Exito")
                {
                    ViewBag.Success = "Exito";
                }
                else
                {
                    ViewBag.error = e.Message;
                }


            }
            return View(mant);




        }

        public IActionResult VerMantenimiento(int id)
        {

            try
            {

                Cabania cabania = _listarCabania.ListarUna(id);
                ViewBag.id = id;

                return View(_listarCabania.ListarMantenimientoPorCabania(cabania));

            }
            catch
            {

                return RedirectToAction("VerMantenimiento");
            }
        }

        public IActionResult BuscarPorFecha(int id, DateTime Fecha1, DateTime Fecha2)
        {

            try
            {
                ViewBag.Id = id;
                return View("VerMantenimiento", _listarCabania.ListarMantenimientoPorFecha(id, Fecha1, Fecha2));
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }


        }
    }
}

