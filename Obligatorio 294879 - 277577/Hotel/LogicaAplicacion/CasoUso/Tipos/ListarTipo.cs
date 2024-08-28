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
    public class ListarTipo : IListarTipo
    {
        private IRepositorioTipo _repo;
        public ListarTipo(IRepositorioTipo repo)
        {
            _repo = repo;
        }

        public IEnumerable<Tipo> ListarTodo()
        {
            return _repo.GetAll();
        }

        public IEnumerable<Tipo> ListarTipoPorNombre(string nombre)
        {
            return _repo.GetTipoByName(nombre);
        }

        public Tipo ListarUnTipoPorNombre(string nombre)
        {
            Tipo tipo = _repo.GetUnTipoByName(nombre);
            return tipo;
        }

        public Tipo ListarUno(int id)
        {
            return _repo.Get(id);
        }



    }
}
