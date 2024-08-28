using LogicaAccesoDatos.EF;
using LogicaAplicacion.CasoUso.Interfaces;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasoUso.Tipos
{
    public class BajaTipo : IBaja
    {
        private IRepositorioTipo _repo;

        public BajaTipo(IRepositorioTipo repo)
        {
            _repo = repo;
        }

        public void Borrar(int id)
        {
            try
            {
                _repo.Delete(id);

            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
