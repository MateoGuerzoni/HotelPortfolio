using LogicaAccesoDatos.EF;
using LogicaAplicacion.CasoUso.Interfaces;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasoUso.Usuarios
{
    public class BajaUsuario : IBaja
    {
        private IRepositorioUsuario _repo;

        public BajaUsuario(IRepositorioUsuario repo)
        {
            _repo = repo;
        }


        public void Borrar(int id)
        {
            _repo.Delete(id);
        }
    }
}