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
    public class EditarTipo : IEditar<Tipo>
    {

        private IRepositorioTipo _repo;

        public EditarTipo(IRepositorioTipo repo)
        {
            _repo = repo;
        }

        public void Editar(Tipo obj)
        {
            try
            {
                _repo.Update(obj);

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
