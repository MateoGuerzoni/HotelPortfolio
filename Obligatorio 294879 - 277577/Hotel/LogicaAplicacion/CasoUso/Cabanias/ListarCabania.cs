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
    public class ListarCabania : IListarCabania
    {

        private IRepositorioCabania _repo;
        public ListarCabania(IRepositorioCabania repo)
        {
            _repo = repo;
        }

        public Cabania ListarUna(int id)
        {
            return _repo.Get(id);
        }

        public IEnumerable<Cabania> ListarTodo()
        {
            return _repo.GetAll();
        }

        public IEnumerable<Cabania> ListarCabaniasNombre(string nombre)
        {
            return _repo.GetCabaniaByName(nombre);
        }

        public IEnumerable<Cabania> ListarCabaniaPorTipo(string nombre)
        {
            return _repo.GetTipoCabaniaByName(nombre);
        }

        public IEnumerable<Cabania> ListarCabaniaPorHuespedes(int huespedes)
        {
            return _repo.GetCabaniaByQuantity(huespedes);
        }

        public IEnumerable<Cabania> ListarCabaniaPorEstado(bool estado)
        {

            return _repo.GetCabaniaByState(estado);
        }

        public IEnumerable<Mantenimiento> ListarMantenimientoPorCabania(Cabania cabania)
        {
            return _repo.GetMantemientosCabania(cabania);
        }

        public IEnumerable<Mantenimiento> ListarMantenimientoPorFecha(int id, DateTime Fecha1, DateTime Fecha2)
        {

            return _repo.GetMantemientosFecha(id, Fecha1, Fecha2);
        }

        public IEnumerable<Mantenimiento> ListarMantenimientosDiarios(Cabania cabania)
        {
            return _repo.GetMantenimientosDiarios(cabania);
        }

        public IEnumerable<Cabania> ListarCabaniasConCostoMenor(int monto)
        {
            return _repo.ObtenerCabaniasConCostoMenor(monto);
        }

        public IEnumerable<MantenimientoPorPersona> ListarMantenimientosPorCapacidad(int min, int max)
        {
            return _repo.ObtenerMantenimientosPorCapacidad(min, max);
        }
    }
}
