using LogicaAccesoDatos.EF;
using LogicaAplicacion.CasoUso.Interfaces;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasoUso.Usuarios
{
    public class ValidarUsuario : IValidarUsuario
    {
        private IRepositorioUsuario _repo;
        public ValidarUsuario(IRepositorioUsuario repo)
        {
            _repo = repo;
        }

        public bool ValidarEmailContrasenia(string email, string pass)
        {
            try
            {
                return _repo.ChequearContraseniaPorUsuario(email, pass) ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}