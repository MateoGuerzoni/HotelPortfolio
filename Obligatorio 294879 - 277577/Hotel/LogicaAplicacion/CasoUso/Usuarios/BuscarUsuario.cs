using LogicaAccesoDatos.EF;
using LogicaAplicacion.CasoUso.Interfaces;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasoUso.Usuarios
{
    public class BuscarUsuario : IBuscarUsuario
    {
        private IRepositorioUsuario _repo;
        public BuscarUsuario(IRepositorioUsuario repo)
        {
            _repo = repo;
        }

        public Usuario BuscarPorMail(string email)
        {
            return _repo.GetUsuarioByMail(email);
        }

        public IEnumerable<Usuario> BuscarTodos()
        {
            return _repo.GetAll();
        }

    }
}
