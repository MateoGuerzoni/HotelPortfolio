using LogicaNegocio.Entidades;

namespace LogicaAplicacion.CasoUso.Interfaces
{
    public interface IListarCabania
    {
        public Cabania ListarUna(int id);
        public IEnumerable<Cabania> ListarTodo();
        public IEnumerable<Cabania> ListarCabaniasNombre(string nombre);
        public IEnumerable<Cabania> ListarCabaniaPorTipo(string nombre);
        public IEnumerable<Cabania> ListarCabaniaPorHuespedes(int huespedes);
        public IEnumerable<Cabania> ListarCabaniaPorEstado(bool estado);
        public IEnumerable<Mantenimiento> ListarMantenimientoPorCabania(Cabania cabania);
        public IEnumerable<Mantenimiento> ListarMantenimientoPorFecha(int id, DateTime Fecha1, DateTime Fecha2);
        public IEnumerable<Mantenimiento> ListarMantenimientosDiarios(Cabania cabania);
        public IEnumerable<Cabania> ListarCabaniasConCostoMenor(int monto);
        public IEnumerable<MantenimientoPorPersona> ListarMantenimientosPorCapacidad(int min, int max);




    }
}