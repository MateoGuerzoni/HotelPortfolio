using AutoMapper;
using LogicaAccesoDatos.EF.Excepciones;
using LogicaAplicacion.CasoUso.Cabanias;
using LogicaAplicacion.CasoUso.Interfaces;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.CabaniaExcepciones;
using LogicaNegocio.Excepciones.DominioExcepciones;
using LogicaNegocio.Excepciones.MantenimientoExcepciones;
using LogicaNegocio.Excepciones.TipoExcepciones;
using LogicaNegocio.Vo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposController : ControllerBase
    {
        private IAltaTipo _altaTipo;
        private IListarTipo _listarTipo;
        private IEditar<Tipo> _editarTipo;
        private IBaja _bajaTipo;
        private IMapper _mapper;
        public TiposController(
            IAltaTipo altaTipo,
            IListarTipo listarTipo,
            IEditar<Tipo> editarTipo,
            IBaja bajaTipo,
            IMapper mapper

            )
        {
            _altaTipo = altaTipo;
            _listarTipo = listarTipo;
            _editarTipo = editarTipo;
            _bajaTipo = bajaTipo;
            _mapper = mapper;

        }

        /// <summary>
        /// Obtiene una lista de todos los tipos y la devuelve
        ///  
        /// StatusCode Success: 200
        /// StatusCode Error: 404,400
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<TipoDto> list = _mapper.Map<List<TipoDto>>(_listarTipo.ListarTodo());
                if (list.Count() <= 0)
                {
                    throw new NotFoundException("No se encontraron tipos");
                }
                return Ok(list);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest("Error en la opreación, vuelva a intentarlo mas tarde.");
            }
        }

        /// <summary>
        ///  Obtiene 1 mantenimiento por nombre y lo devuelve
        /// StatusCode Success: 200
        /// StatusCode Error: 500,404,400
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("name/{name}")]
        public IActionResult GetByName(string name)
        {


            try
            {
                TipoDto tipoDto = _mapper.Map<TipoDto>(_listarTipo.ListarUnTipoPorNombre(name));
                return Ok(tipoDto);
            }
            catch (TipoNombreException e)
            {
                return BadRequest(e.Message);
            }
            catch (TipoException e)
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
        /// Da de alta un tipo
        ///  
        /// StatusCode Success: 201
        /// StatusCode Error: 409,400
        /// </summary>
        /// <param name="tipoDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public IActionResult Post(TipoDto tipoDto)
        {
            try
            {

                //Cabania c = _mapper.Map<Cabania>(cabaniaDto);

                //_altaCabania.Crear(c);

                Tipo tipo = _mapper.Map<Tipo>(tipoDto);

                _altaTipo.Crear(tipo);
                // estas respuesta esta mal porque me devuelve 200, no retorna el objeto
                // y no me indica como obtener el dato
                //return Ok("prueba");
                return CreatedAtAction("GetById", new { id = tipo.Id }, tipo);
            }
            catch (TipoNombreException ex)
            {
                return StatusCode(409, ex.Message);
            }
            catch (TipoDescripcionException ex)
            {
                return StatusCode(409, ex.Message);
            }
            catch (TipoCostoException ex)
            {
                return StatusCode(409, ex.Message);
            }
            catch (Exception)
            {
                return BadRequest("Error a dar de alta");
            }

        }

        /// <summary>
        ///  Edita un tipo seleccionado
        /// StatusCode Success: 200
        /// StatusCode Error: 409,404,400
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tipo"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Update(int id, TipoDto tipo)
        {
            try
            {


                Tipo t = _listarTipo.ListarUno(id);

                if (t.Nombre == null)
                {
                    return BadRequest();
                }
                else if (t.Descripcion == null)
                {
                    return BadRequest();
                }
                else if (t.CostoPorHuesped == null)
                {
                    return BadRequest();
                }
                else
                {
                    t.Nombre = tipo.Nombre;
                    t.Descripcion = tipo.Descripcion;
                    t.CostoPorHuesped = tipo.CostoPorHuesped;
                }
                _editarTipo.Editar(t);
                return Ok("Se modifico");
            }
            catch (TipoNombreException ex)
            {
                return StatusCode(409, ex.Message);
            }
            catch (TipoDescripcionException ex)
            {
                return StatusCode(409, ex.Message);
            }
            catch (TipoCostoException ex)
            {
                return StatusCode(409, ex.Message);
            }
            catch (Exception)
            {
                return BadRequest("Error en la operación, vuelva a intentar mas tarde");
            }
        }

        /// <summary>
        ///  Da de baja un Tipo por Id
        /// StatusCode Success: 204
        /// StatusCode Error: 404,400
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public IActionResult Delete(int id)
        {
            try
            {
                Tipo tipo = _listarTipo.ListarUno(id);
                if (tipo != null)
                {

                    _bajaTipo.Borrar(tipo.Id);
                    return StatusCode(204, "se dio de baja");
                }
                else
                {
                    throw new NotFoundException("No se encontró Tipo con ese id");
                }

            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }


    }
}
