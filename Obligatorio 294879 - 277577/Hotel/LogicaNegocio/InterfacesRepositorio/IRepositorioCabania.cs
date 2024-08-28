using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioCabania : IRepositorio<Cabania>
    {
        public IEnumerable<Cabania> GetCabaniaByName(string name);
        public IEnumerable<Cabania> GetCabaniaByType(Tipo tipo);
        public IEnumerable<Cabania> GetCabaniaByQuantity(int huespedes);
        public IEnumerable<Cabania> GetCabaniaByState(bool estado);

        public IEnumerable<Mantenimiento> GetMantemientosCabania(Cabania cabania);

        public IEnumerable<Mantenimiento> GetMantemientosFecha(int id,DateTime Fecha1, DateTime Fecha2);

        public IEnumerable<Mantenimiento> GetMantenimientosDiarios(Cabania cabania);
        public IEnumerable<Cabania> ObtenerCabaniasConCostoMenor(int monto);
        public IEnumerable<MantenimientoPorPersona> ObtenerMantenimientosPorCapacidad(int min, int max);
        IEnumerable<Cabania> GetTipoCabaniaByName(string nombre);
        void AgregarMantenimiento(Mantenimiento mantenimiento);
        int ObtenerUltimoNumDeCabania();
    }
}
