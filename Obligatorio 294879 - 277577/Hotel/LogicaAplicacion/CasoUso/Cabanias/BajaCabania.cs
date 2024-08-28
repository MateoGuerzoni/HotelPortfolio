using LogicaAccesoDatos.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.Entidades;
using LogicaAplicacion.CasoUso.Interfaces;
using LogicaNegocio.InterfacesRepositorio;

namespace LogicaAplicacion.CasoUso.Cabanias
{
    public class BajaCabania : IBaja
    {

        private IRepositorioCabania _repo;

        public BajaCabania(IRepositorioCabania repo)
        {
            _repo = repo;
        }

        public void Borrar(int id)
        {
            _repo.Delete(id);
        }
    }
}
