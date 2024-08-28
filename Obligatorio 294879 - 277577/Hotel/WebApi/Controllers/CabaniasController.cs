using LogicaAplicacion.CasoUso.Interfaces;
using LogicaNegocio.Entidades;
using LogicaNegocio.Vo;
using LogicaAccesoDatos.EF.Excepciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using LogicaNegocio.Excepciones.CabaniaExcepciones;
using LogicaNegocio.Excepciones.MantenimientoExcepciones;
using LogicaNegocio.Excepciones.TipoExcepciones;
using LogicaNegocio.Excepciones.DominioExcepciones;
using AutoMapper;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CabaniasController : ControllerBase
    {

        private IAltaCabania _altaCabania;
        private IListarCabania _listarCabania;
        private IBaja _bajaCabania;
        private IListarTipo _listarTipo;
        private IWebHostEnvironment _environment;
        private IMapper _mapper;


        public CabaniasController(
            IAltaCabania altaCabania,
            IListarCabania listarCabania,
            IBaja bajaCabania,
            IListarTipo listarTipo,
            IWebHostEnvironment environment,
            IMapper mapper

            )
        {
            _altaCabania = altaCabania;
            _bajaCabania = bajaCabania;
            _listarCabania = listarCabania;
            _listarTipo = listarTipo;
            _environment = environment;
            _mapper = mapper;


        }

        /// <summary>
        /// Busca y devuelve una lista con todas las cabañas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {

                List<CabaniaDto> list = _mapper.Map<List<CabaniaDto>>(_listarCabania.ListarTodo());

                return Ok(list);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Busca cabañas por nombre y devuelve la lista
        /// StatusCode Success: 200
        /// StatusCode Error: 500,400
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("name/{name}")]
        public IActionResult GetByName(string name)
        {

            try
            {

                List<CabaniaDto> list = _mapper.Map<List<CabaniaDto>>(_listarCabania.ListarCabaniasNombre(name));

                if (list.Count() <= 0)
                {
                    throw new CabaniaNombreException("No se encontraron cabañas con ese nombre.");
                }


                return Ok(list);
            }
            catch (CabaniaNombreException e)
            {
                return BadRequest(e.Message);
            }
            catch (CabaniaException e)
            {
                return BadRequest(e.Message);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Intente nuevamente en unos minutos");
            }

        }

        /// <summary>
        /// Busca cabañas por nombre del tipo y devuelve lista
        /// StatusCode Success: 200
        /// StatusCode Error: 500,404,400
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        [HttpGet("tipo/{tipo}")]
        public IActionResult GetByTipo(string tipo)
        {
            try
            {
                List<CabaniaDto> list = _mapper.Map<List<CabaniaDto>>(_listarCabania.ListarCabaniaPorTipo(tipo));

                if (list.Count() <= 0)
                {
                    throw new NotFoundException("No se encontraron cabañas con ese tipo.");
                }
                return Ok(list);
            }
            catch (CabaniaNombreException e)
            {
                return BadRequest(e.Message);
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Intente nuevamente en unos minutos");
            }

        }
        /// <summary>
        /// Buca cabañas por capacidad y devuelve mayores a ese valor
        /// StatusCode Success: 200
        /// StatusCode Error: 500,404,400
        /// </summary>
        /// <param name="huespedes"></param>
        /// <returns></returns>
        [HttpGet("huespedes/{huespedes}")]
        public IActionResult GetByHuespedes(int huespedes)
        {
            try
            {
                List<CabaniaDto> list = _mapper.Map<List<CabaniaDto>>(_listarCabania.ListarCabaniaPorHuespedes(huespedes));
                if (list.Count() <= 0)
                {
                    throw new CabaniaCantHuespedesException("No se encontraron cabañas con esos huespedes.");
                }
                return Ok(list);
            }
            catch (CabaniaCantHuespedesException e)
            {
                return BadRequest(e.Message);
            }
            catch (CabaniaException e)
            {
                return BadRequest(e.Message);
            }
            catch (DomainException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Intente nuevamente en unos minutos");
            }

        }

        /// <summary>
        /// Busca cabañas por estado y devuelve lista 
        /// StatusCode Success: 200
        /// StatusCode Error: 500,404,400
        /// </summary>
        /// <param name="estado"></param>
        /// <returns></returns>
        [HttpGet("estado/{estado}")]
        public IActionResult GetByEstado(bool estado)
        {

            try
            {

                List<CabaniaDto> list = _mapper.Map<List<CabaniaDto>>(_listarCabania.ListarCabaniaPorEstado(estado));

                if (list.Count() <= 0)
                {
                    throw new NotFoundException("No se encontraron cabañas con ese estado.");
                }
                return Ok(list);
            }
            catch (CabaniaNombreException e)
            {
                return BadRequest(e.Message);
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Intente nuevamente en unos minutos");
            }

        }

        /// <summary>
        /// Obtiene una cabaña por el id 
        /// StatusCode Success: 200
        /// StatusCode Error: 500,404,400
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("id/{id}")]
        public IActionResult GetById(int? id)
        {
            try
            {

                Cabania cabania = _listarCabania.ListarUna((int)id);
                CabaniaDto cabaniaDto = _mapper.Map<CabaniaDto>(cabania);

                return Ok(cabaniaDto);
            }
            catch (CabaniaIdException e)
            {
                return StatusCode(409, e.Message);
            }
            catch (CabaniaException e)
            {
                return BadRequest(e.Message);
            }
            catch (DomainException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error en la operación, vuelva a intentarlo mas tarde");
            }

        }


        /// <summary>
        ///  Crea una cabaña
        /// StatusCode Success: 201
        /// StatusCode Error: 500,409
        /// </summary>
        /// <param name="cabaniaDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]

        public IActionResult Post(CabaniaDto cabaniaDto)
        {
            try
            {
                Cabania c = _mapper.Map<Cabania>(cabaniaDto);

                _altaCabania.Crear(c);
                cabaniaDto.numHabitacion = c.numHabitacion;

                return CreatedAtAction("GetById", new { id = c.numHabitacion }, cabaniaDto);
            }
            catch (CabaniaNombreException ex)
            {

                return StatusCode(409, ex.Message);
            }
            catch (CabaniaCantHuespedesException ex)
            {
                return StatusCode(409, ex.Message);

            }
            catch (CabaniaDescripcionException ex)
            {
                return StatusCode(409, ex.Message);

            }
            catch (TipoIdException ex)
            {
                return StatusCode(409, ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error intente de nuevo mas tarde"); ;
            }

        }

        /// <summary>
        ///  Agrega mantenimiento a cabaña
        /// StatusCode Success: 200
        /// StatusCode Error: 400,409
        /// </summary>
        /// <param name="mant"></param>
        /// <param name="IdCabania"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("mantenimiento/{IdCabania}")]
        public IActionResult AddMantenimiento(MantenimientoDto mant, int IdCabania)
        {
            try
            {
                Cabania cabania = _listarCabania.ListarUna(IdCabania);


                if (_listarCabania.ListarMantenimientosDiarios(cabania).Count() >= 3)
                {
                    return BadRequest("La cabania ya tiene mas de 3 mantenimientos en el dia");
                }

                Mantenimiento m = _mapper.Map<Mantenimiento>(mant);

                //m.CabaniaRealizada = cabania;

                _altaCabania.CrearMantenimineto(m);


                return Ok(m);

            }
            catch (MantenimientoCostoException ex)
            {
                return StatusCode(409, ex.Message);

            }
            catch (MantenimientoDescripcionException ex)
            {
                return StatusCode(409, ex.Message);
            }
            catch (CabaniaNombreException ex)
            {
                return StatusCode(409, ex.Message);
            }
            catch (Exception)
            {
                return BadRequest("Error al dar de alta, intente mas tarde");
            }

        }

        /// <summary>
        /// Obtiene mantenimientos por Id de cabaña

        /// StatusCode Success: 200
        /// StatusCode Error: 404
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("mantenimiento/{id}")]
        public IActionResult GetMantenimientos(int id)
        {
            try
            {
                Cabania cabania = _listarCabania.ListarUna(id);


                List<MantenimientoDto> list = _mapper.Map<List<MantenimientoDto>>(_listarCabania.ListarMantenimientoPorCabania(cabania));

                if (list.Count() <= 0)
                {
                    throw new NotFoundException("No se encontraron mantenimientos con ese estado.");
                }
                return Ok(list);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// Obtiene lista de mantenimientos entre fechas
        ///  
        /// StatusCode Success: 200
        /// StatusCode Error: 404,400
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Fecha1"></param>
        /// <param name="Fecha2"></param>
        /// <returns></returns>
        [HttpGet("mantenimiento/{id},{Fecha1},{Fecha2}")]
        public IActionResult GetMantenimientosPorFecha(int id, DateTime Fecha1, DateTime Fecha2)
        {
            try
            {

                List<MantenimientoDto> list = _mapper.Map<List<MantenimientoDto>>(_listarCabania.ListarMantenimientoPorFecha(id, Fecha1, Fecha2));

                if (list.Count() <= 0)
                {
                    throw new NotFoundException("No se encontraron mantenimientos con ese estado.");
                }
                return Ok(list);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest("Error en la operación, vuelva a intentar mas tarde");
            }

        }

        /// <summary>
        ///  Obtiene lista de cabanias con valor menor a un monto
        /// StatusCode Success: 200
        /// StatusCode Error: 404,400
        /// </summary>
        /// <param name="monto"></param>
        /// <returns></returns>
        [HttpGet("{monto}")]
        public IActionResult GetCabaniaMenorValor(int monto)
        {
            try
            {

                List<CabaniaDto> list = _mapper.Map<List<CabaniaDto>>(_listarCabania.ListarCabaniasConCostoMenor(monto));

                if (list.Count() <= 0)
                {
                    throw new NotFoundException("No se encontraron mantenimientos con ese estado.");
                }
                return Ok(list);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest("Error en la operación, vuelva a intentar mas tarde");
            }

        }


        /// <summary>
        /// Obtiene mantenimientos hechos a caba;as con una capacidad entre 2 valores
        ///  
        /// StatusCode Success: 200
        /// StatusCode Error: 404,400
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        [HttpGet("{min},{max}")]
        public IActionResult GetMantenimientosEntreValores(int min, int max)
        {
            try
            {
                List<MantenimientoPorPersonaDto> list = new List<MantenimientoPorPersonaDto>();
                //List<MantenimientoPorPersonaDto> list = _mapper.Map<List<MantenimientoPorPersonaDto>>(_listarCabania.ListarMantenimientosPorCapacidad(min,max));

                foreach (var item in _listarCabania.ListarMantenimientosPorCapacidad(min, max))
                {
                    MantenimientoPorPersonaDto mantDto = new MantenimientoPorPersonaDto()
                    {

                        NombrePersona = item.NombrePersona,
                        MontoTotal = item.MontoTotal

                    };
                    list.Add(mantDto);

                }

                if (list.Count() <= 0)
                {
                    throw new NotFoundException("No se encontraron mantenimientos con ese estado.");
                }
                return Ok(list);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest("Error en la operación, vuelva a intentar mas tarde");
            }

        }



    }
}
