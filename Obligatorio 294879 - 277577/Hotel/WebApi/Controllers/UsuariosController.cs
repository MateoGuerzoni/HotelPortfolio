using LogicaAplicacion.CasoUso.Interfaces;
using LogicaNegocio.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IAltaUsuario _altaUsuario;
        private IBaja _bajaUsuario;
        private IBuscarUsuario _buscarUsuario;
        private IValidarUsuario _validarUsuario;
        public UsuariosController(
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

        /// <summary>
        ///  Obtiene lista de todos los usuarios
        /// StatusCode Success: 200
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Usuario> usuarios = _buscarUsuario.BuscarTodos();

            return Ok(usuarios);
        }

        /// <summary>
        ///  Valida que el usuario ingresado en el login sea correcto, devuelve nombre de usuario y token
        /// StatusCode Success: 200
        /// StatusCode Error: 401
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public ActionResult<UsuarioDto> Login([FromBody] UsuarioDto usuario)
        {
            try
            {

                var usr = _buscarUsuario.BuscarPorMail(usuario.Email);
                if (usr == null || usr.Password != usuario.Password)
                    return Unauthorized("Credenciales inválidas. Reintente");

                //Le pedimos al manejador de tokens que nos genere un token jwt con
                //la información del usuario para usar como claims (el email y el nombre de rol)
                var token = ManejadorJwt.GenerarToken(usr);

                DtoUsuarioLogueado usuarioLogueado = new DtoUsuarioLogueado()
                {
                    EmailUsuario = usuario.Email,
                    Token = token
                };
                return Ok(usuarioLogueado);

            }
            catch (Exception ex)
            {
                return Unauthorized(new { Message = "Se produjo un error. Intente n" });
            }
        }

    }
}
