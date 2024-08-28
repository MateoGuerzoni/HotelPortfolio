using LogicaAccesoDatos.EF;
using LogicaAplicacion.CasoUso.Interfaces;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasoUso.Usuarios
{
    public class AltaUsuario : IAltaUsuario
    {


        private IRepositorioUsuario _repo;
        public AltaUsuario(IRepositorioUsuario repo)
        {
            _repo = repo;
        }

        public void Crear(Usuario usuario)
        {
            _repo.Add(usuario);

        }

        public void PrecargaUsers()
        {
            _repo.precargarUsuarios();
        }
    }
}
