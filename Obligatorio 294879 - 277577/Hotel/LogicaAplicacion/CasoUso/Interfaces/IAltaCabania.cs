using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.Entidades;

namespace LogicaAplicacion.CasoUso.Interfaces
{
    public interface IAltaCabania
    {
        public void Crear(Cabania obj);

        public void CrearMantenimineto(Mantenimiento mantenimiento);
        public int ObtenerNumHabitacion();

    }
}
